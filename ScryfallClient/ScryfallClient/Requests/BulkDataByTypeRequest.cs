using ScryfallClient.Attributes;
using ScryfallClient.Enums;
using ScryfallClient.Requests.Interfaces;

namespace ScryfallClient.Requests
{
    public class BulkDataByTypeRequest : IRequest
    {
        public string EndpointUri => "bulk-data/<type>";
        public string Method => "GET";

        /// <summary>
        /// The Bulk Data type.
        /// </summary>
        [QueryParameter("type", IsPartOfPath = true)]
        public string Type { get; set; } = null!;

        /// <summary>
        /// The data format to return: json or file.
        /// Defaults to json.
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
