using System;

namespace ScryfallClient.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class QueryParameterAttribute : System.Attribute
    {
        public string Name { get; set; }
        public string[] DependsOn { get; set; }
        public bool IsPartOfPath { get; set; }
        
        public QueryParameterAttribute(string name)
        {
            Name = name;
            DependsOn = Array.Empty<string>();
            IsPartOfPath = false;
        }
    }
}