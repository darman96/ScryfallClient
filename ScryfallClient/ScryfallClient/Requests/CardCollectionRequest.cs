using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using ScryfallClient.Attributes;
using ScryfallClient.Requests.Interfaces;

namespace ScryfallClient.Requests
{
    public class CardCollectionRequest : IRequest
    {
        public class CardIdentifier
        {
            [JsonPropertyName("id")]
            public Guid? Id { get; set; }
            [JsonPropertyName("mtgo_id")]
            public int? MtgoId { get; set; }
            [JsonPropertyName("multiverse_id")]
            public int? MultiverseId { get; set; }
            [JsonPropertyName("oracle_id")]
            public Guid? OracleId { get; set; }
            [JsonPropertyName("illustration_id")]
            public Guid? IllustrationId { get; set; }
            [JsonPropertyName("name")]
            public string? Name { get; set; }
            [JsonPropertyName("set")]
            public string? Set { get; set; }
            [JsonPropertyName("collector_number")]
            public string? CollectorNumber { get; set; }
        }
        
        public string EndpointUri => "cards/collection";
        public string Method => "POST";
        
        /// <summary>
        /// An array of JSON objects, each one a <see cref="CardIdentifier"/>,.
        /// </summary>
        [RequestBody]
        public List<CardIdentifier> Identifiers { get; set; } = new List<CardIdentifier>();

        /// <summary>
        /// The data format to return. This method only supports json.
        /// </summary>
        [QueryParameter("format")]
        public string Format => "json";
        
        /// <summary>
        /// If true, the returned JSON will be prettified. Avoid using for production code.
        /// </summary>
        [QueryParameter("pretty" , DependsOn = new []{ "format=json" })]
        public bool? Pretty { get; set; }
    }
}