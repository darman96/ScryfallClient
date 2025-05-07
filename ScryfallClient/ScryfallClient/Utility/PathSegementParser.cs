using ScryfallClient.Utility.Interfaces;
using ScryfallClient.Utility.Structs;

namespace ScryfallClient.Utility
{
    public class PathSegementParser : IPathSegementParser
    {
        public PathSegment Parse(string segment)
        {
            if (isParameterSegment(segment))
            {
                return new PathSegment
                {
                    Name = getParameterName(segment),
                    IsOptional = isOptionalParameterSegment(segment),
                    IsParameter = true
                };
            }

            return new PathSegment
            {
                Name = segment,
                IsOptional = false,
                IsParameter = false
            };
        }
        
        private static bool isParameterSegment(string segment)
            => segment.StartsWith("<") && segment.EndsWith(">");
        
        private static bool isOptionalParameterSegment(string segment)
            => segment.StartsWith("<?") && segment.EndsWith(">");
        
        private static string getParameterName(string segment)
            => segment.Substring(1, segment.Length - 2).TrimStart('?');
    }
}