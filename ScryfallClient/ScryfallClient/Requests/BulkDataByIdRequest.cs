using System;
using ScryfallClient.Attributes;
using ScryfallClient.Enums;
using ScryfallClient.Requests.Interfaces;

namespace ScryfallClient.Requests
{
    public class BulkDataByIdRequest : IRequest
    {
        public string EndpointUri => "bulk-data/<id>";
        public string Method => "GET";

        /// <summary>
        /// The id of the Bulk Data object.
        /// </summary>
        [QueryParameter("id", IsPartOfPath = true)]
        public Guid Id { get; set; }

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
