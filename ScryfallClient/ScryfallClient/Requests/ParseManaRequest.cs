using ScryfallClient.Attributes;
using ScryfallClient.Requests.Interfaces;

namespace ScryfallClient.Requests
{
    /// <summary>
    /// Represents a request to the /symbology/parse-mana endpoint.
    /// Parses a mana cost string and returns Scryfall’s interpretation.
    /// </summary>
    public class ParseManaRequest : IRequest
    {
        /// <inheritdoc />
        public string EndpointUri => "symbology/parse-mana";

        /// <inheritdoc />
        public string Method => "GET";

        /// <summary>
        /// The mana string to parse.
        /// </summary>
        [QueryParameter("cost")]
        public string Cost { get; set; } = null!;

        /// <summary>
        /// The data format to return. This method only supports json.
        /// </summary>
        [QueryParameter("format")]
        public string Format => "json";

        /// <summary>
        /// If true, the returned JSON will be prettified.
        /// Avoid using for production code.
        /// </summary>
        [QueryParameter("pretty", DependsOn = new[] { "format=json" })]
        public bool? Pretty { get; set; }
    }
}