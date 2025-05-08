using ScryfallClient.Attributes;
using ScryfallClient.Requests.Interfaces;

namespace ScryfallClient.Requests
{
    /// <summary>
    /// Represents a request to retrieve rulings for a card by its set code and collector number.
    /// </summary>
    public class RulingsByCollectorInfoRequest : IRequest
    {
        public string EndpointUri => $"cards/<code>/<number>/rulings";
        public string Method => "GET";

        /// <summary>
        /// The three to five-letter set code.
        /// </summary>
        [QueryParameter("code", IsPartOfPath = true)]
        public string Code { get; set; } = null!;

        /// <summary>
        /// The collector number.
        /// </summary>
        [QueryParameter("number", IsPartOfPath = true)]
        public string Number { get; set; } = null!;

        /// <summary>
        /// The data format to return. This method only supports json.
        /// </summary>
        [QueryParameter("format")]
        public string Format => "json";
        
        /// <summary>
        /// If true, the returned JSON will be prettified.
        /// Avoid using for production code.
        /// </summary>
        [QueryParameter("pretty", DependsOn = new []{ "format=json" })]
        public bool? Pretty { get; set; }
    }
}
