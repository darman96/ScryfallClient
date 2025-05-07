using System;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using ScryfallClient.Attributes;
using ScryfallClient.Extensions;
using ScryfallClient.Requests.Interfaces;
using ScryfallClient.Utility.Interfaces;

namespace ScryfallClient.Utility
{
    internal class RequestBodyFactory : IRequestBodyFactory
    {
        public string Create(IRequest request)
        {
            var properties = request
                .GetType()
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.HasCustomAttribute<RequestBodyAttribute>())
                .ToArray();
            
            if (properties.Length > 1) 
                throw new InvalidOperationException("Only one property can be marked with RequestBodyAttribute per request");
            
            var bodyObject = properties[0]
                .GetValue(request);
            
            return JsonSerializer.Serialize(bodyObject);
        }
    }
}