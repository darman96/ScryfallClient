using ScryfallClient.Attributes;
using ScryfallClient.Enums;
using ScryfallClient.Requests.Interfaces;

namespace ScryfallClient.Requests
{
    /// <summary>
    /// Represents a request to retrieve a set by its code.
    /// </summary>
    public class SetByCodeRequest : IRequest
    {
        public string EndpointUri => "sets/<Code>";
        public string Method => "GET";

        /// <summary>
        /// The three to five-letter set code.
        /// </summary>
        [QueryParameter("Code", IsPartOfPath = true)]
        public string Code { get; set; } = null!;

        /// <summary>
        /// The data format to return. This method only supports json.
        /// </summary>
        [QueryParameter("format")]
        public string? Format => "json";

        /// <summary>
        /// If true, the returned JSON will be prettified.
        /// Avoid using for production code.
        /// </summary>
        [QueryParameter("pretty" , DependsOn = new []{ "format=json" })]
        public bool? Pretty { get; set; }
    }
}
