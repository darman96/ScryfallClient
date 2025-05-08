using ScryfallClient.Requests.Interfaces;
using ScryfallClient.Attributes;

namespace ScryfallClient.Requests
{
    public class CatalogLoyaltiesRequest : IRequest
    {
        public string EndpointUri => "catalog/loyalties";
        public string Method => "GET";

        /// <summary>
        /// The data format to return: json or csv.
        /// Defaults to json.
        /// </summary>
        [QueryParameter("format")]
        public string Format { get; set; } = "json";
        
        /// <summary>
        /// If true, the returned JSON will be prettified. Avoid using for production code.
        /// </summary>
        [QueryParameter("pretty", DependsOn = new []{ "format=json" })]
        public bool? Pretty { get; set; }
    }
}
