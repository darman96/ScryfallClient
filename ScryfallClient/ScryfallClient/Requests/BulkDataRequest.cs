using ScryfallClient.Attributes;
using ScryfallClient.Enums;
using ScryfallClient.Requests.Interfaces;

namespace ScryfallClient.Requests
{
    public class BulkDataRequest : IRequest
    {
        public string EndpointUri => "bulk-data";
        public string Method => "GET";

        /// <summary>
        /// The data format to return.
        /// </summary>
        [QueryParameter("format")]
        public ResponseFormat? Format { get; set; }

        /// <summary>
        /// If true, the returned JSON will be prettified.
        /// Avoid using for production code.
        /// </summary>
        [QueryParameter("pretty")]
        public bool? Pretty { get; set; }
    }
}
