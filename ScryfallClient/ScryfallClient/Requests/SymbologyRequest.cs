using ScryfallClient.Attributes;
using ScryfallClient.Requests.Interfaces;

namespace ScryfallClient.Requests
{
    /// <summary>
    /// Represents a request to the /symbology endpoint.
    /// Returns a List of all Card Symbols.
    /// </summary>
    public class SymbologyRequest : IRequest
    {
        /// <inheritdoc />
        public string EndpointUri => "symbology";

        /// <inheritdoc />
        public string Method => "GET";

        /// <summary>
        /// The data format to return. This method only supports json.
        /// </summary>
        [QueryParameter("format")]
        public string Format => "json";

        /// <summary>
        /// If true, the returned JSON will be prettified. Avoid using for production code.
        /// </summary>
        [QueryParameter("pretty", DependsOn = new[] { "format=json" })]
        public bool? Pretty { get; set; }
    }
}