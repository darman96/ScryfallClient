using ScryfallClient.Attributes;
using ScryfallClient.Requests.Interfaces;

namespace ScryfallClient.Requests
{
    public class CardAutocompleteRequest : IRequest
    {
        public string EndpointUri => "cards/autocomplete";
        public string Method => "GET";
        
        /// <summary>
        /// The string to autocomplete.
        /// </summary>
        [QueryParameter("q")]
        public string Query { get; set; } = null!;

        /// <summary>
        /// The data format to return. This method only supports json.
        /// </summary>
        [QueryParameter("format")]
        public string Format => "json";

        /// <summary>
        /// If true, the returned JSON will be prettified. Avoid using for production code.
        /// </summary>
        [QueryParameter("pretty" , DependsOn = new []{ "format=json" })]
        public bool? Pretty { get; set; }
        
        /// <summary>
        /// If true, extra cards (tokens, planes, vanguards, etc) will be included.
        /// Defaults to false.
        /// </summary>
        [QueryParameter("include_extras")]
        public bool? IncludeExtras { get; set; }
    }
}