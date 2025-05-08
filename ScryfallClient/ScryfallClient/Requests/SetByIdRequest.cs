using System;
using ScryfallClient.Attributes;
using ScryfallClient.Enums;
using ScryfallClient.Requests.Interfaces;

namespace ScryfallClient.Requests
{
    /// <summary>
    /// Represents a request to retrieve a set by its Scryfall ID.
    /// </summary>
    public class SetByIdRequest : IRequest
    {
        public string EndpointUri => "sets/<Id>";
        public string Method => "GET";

        /// <summary>
        /// The Scryfall ID of the set.
        /// </summary>
        [QueryParameter("Id", IsPartOfPath = true)]
        public Guid Id { get; set; }

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
