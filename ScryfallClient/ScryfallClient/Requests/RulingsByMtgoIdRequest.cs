using ScryfallClient.Attributes;
using ScryfallClient.Requests.Interfaces;

namespace ScryfallClient.Requests
{
    /// <summary>
    /// Represents a request to retrieve rulings for a card by its MTGO ID.
    /// </summary>
    public class RulingsByMtgoIdRequest : IRequest
    {
        public string EndpointUri => $"cards/mtgo/<id>/rulings";
        public string Method => "GET";

        /// <summary>
        /// The MTGO ID of the card.
        /// </summary>
        [QueryParameter("id", IsPartOfPath = true)]
        public int Id { get; set; }

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
