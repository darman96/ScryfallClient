using ScryfallClient.Attributes;
using ScryfallClient.Enums;
using ScryfallClient.Requests.Interfaces;

namespace ScryfallClient.Requests
{
    /// <summary>
    /// Represents a request to retrieve a set by its TCGPlayer ID.
    /// </summary>
    public class SetByTcgPlayerIdRequest : IRequest
    {
        public string EndpointUri => "sets/tcgplayer/<Id>";
        public string Method => "GET";

        /// <summary>
        /// The tcgplayer_id or groupId.
        /// </summary>
        [QueryParameter("Id", IsPartOfPath = true)]
        public int Id { get; set; }

        /// <summary>
        /// The data format to return. This method only supports json.
        /// </summary>
        [QueryParameter("format")]
        public string? Format => "json";

        /// <summary>
        /// If true, the returned JSON will be prettified.
        /// Avoid using for production code.
        /// </summary>
        [QueryParameter("pretty", DependsOn = new []{ "format=json" })]
        public bool? Pretty { get; set; }
    }
}
