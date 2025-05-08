using ScryfallClient.Attributes;
using ScryfallClient.Requests.Interfaces;

namespace ScryfallClient.Requests
{
    public class BulkDataRequest : IRequest
    {
        public string EndpointUri => "bulk-data";
        public string Method => "GET";

        /// <summary>
        /// The data format to return. This method only supports json.
        /// </summary>
        [QueryParameter("format")]
        public string Format => "json";

        /// <summary>
        /// If true, the returned JSON will be prettified.
        /// Avoid using for production code.
        /// </summary>
        [QueryParameter("pretty")]
        public bool? Pretty { get; set; }
    }
}
