using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ScryfallClient.Attributes;
using ScryfallClient.Extensions;
using ScryfallClient.Requests.Interfaces;
using ScryfallClient.Utility.Interfaces;

namespace ScryfallClient.Utility
{
    internal class RequestUriFactory : IRequestUriFactory
    {
        private class RequestParameter
        {
            public string Name { get; set; } = null!;
            public string Value { get; set; } = null!;
            public List<string> Dependencies { get; set; } = null!;
        }

        private readonly IPathSegementParser segmentParser;

        public RequestUriFactory(IPathSegementParser segmentParser)
        {
            this.segmentParser = segmentParser;
        }

        public string Create(IRequest request)
        {
            var pathParameters = new List<RequestParameter>();
            var queryParameters = new List<RequestParameter>();

            var properties = request
                .GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance); // Added BindingFlags.Instance

            foreach (var propertyInfo in properties)
            {
                if (!propertyInfo.HasCustomAttribute<QueryParameterAttribute>()) 
                    continue;
                
                var attribute = propertyInfo.GetCustomAttribute<QueryParameterAttribute>()!;
                var value = propertyInfo.GetValue(request)?.ToString(); // Handle potential null value
                
                if (string.IsNullOrEmpty(value))
                    continue;
                
                var parameter = new RequestParameter
                {
                    Name = attribute.Name,
                    Value = value,
                    Dependencies = attribute.DependsOn.ToList()
                };
                
                if (attribute.IsPartOfPath)
                    pathParameters.Add(parameter);
                else
                    queryParameters.Add(parameter);
            }

            var segments = request
                .EndpointUri
                .Split('/');


            var resolvedSegments = new List<string>();
            foreach (var segmentString in segments) // Renamed segment to segmentString for clarity
            {
                var parsedSegment = segmentParser.Parse(segmentString);
                
                if (parsedSegment.IsParameter)
                {
                    var pathParamInfo = pathParameters.FirstOrDefault(p => p.Name == parsedSegment.Name);
                    
                    if (pathParamInfo != null) // Parameter has a value provided (and it's not null/empty due to earlier filtering)
                    {
                        resolvedSegments.Add(pathParamInfo.Value);
                    }
                    else // Property corresponding to parsedSegment.Name was not found in request, or was null/empty
                    {
                        if (parsedSegment.IsOptional)
                        {
                            // For optional parameters not provided, use the parameter's name as a fallback.
                            resolvedSegments.Add(parsedSegment.Name);
                        }
                        else // It's a required parameter but was not found or was null/empty
                        {
                            throw new InvalidOperationException($"Missing value for Required Parameter: {parsedSegment.Name}");
                        }
                    }
                }
                else // It's a literal segment
                {
                    resolvedSegments.Add(parsedSegment.Name);
                }
            }

            var path = string.Join("/", resolvedSegments.Where(s => !string.IsNullOrEmpty(s))); // Ensure empty segments (e.g. from empty EndpointUri) are handled

            var queryParameterStrings = new List<string>();
            foreach (var queryParameter in queryParameters)
            {
                if (checkDependencies(queryParameter, queryParameters))
                {
                    throw new InvalidOperationException($"One ore more Dependencies are missing for Parameter: {queryParameter.Name}");    
                }
                
                queryParameterStrings.Add($"{queryParameter.Name}={queryParameter.Value}");
            }
            
            var query = string.Join("&", queryParameterStrings);
            return $"{path}?{query}";
        }
        
        private bool checkDependencies(RequestParameter parameter, List<RequestParameter> parameters)
        {
            var dependencies = parameter
                .Dependencies
                .Select(d =>
                {
                    var split = d.Split('=');
                    return (Name: split[0], Value: split.Length > 1 ? split[1] : null);
                });

            return dependencies
                .Any(dependency
                    => parameters.None(param
                        => dependency.Name == param.Name &&
                           (dependency.Value == null || dependency.Value == param.Value)));
        }
    }
}