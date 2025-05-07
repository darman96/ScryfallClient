using ScryfallClient.Attributes;
using ScryfallClient.Requests.Interfaces;

namespace ScryfallClient.Requests
{
    public class CardRandomRequest : IRequest
    {
        public string EndpointUri => "cards/random";
        public string Method => "GET";
        
        /// <summary>
        /// An optional fulltext search query to filter the pool of random cards.
        /// Make sure that your parameter is properly encoded.
        /// </summary>
        [QueryParameter("q")]
        public string? Query { get; set; }

        /// <summary>
        /// The data format to return: json, text, or image.
        /// Defaults to json.
        /// </summary>
        [QueryParameter("format")]
        public string Format { get; set; } = "json";
        
        /// <summary>
        /// If using the image format and this parameter has the value back,
        /// the back face of the card will be returned. Will return a 422 if this card has no back face.
        /// </summary>
        [QueryParameter("face", DependsOn = new []{ "format=image" })]
        public string? Face { get; set; }

        /// <summary>
        /// The image version to return when using the image format: small, normal, large, png, art_crop, or border_crop.
        /// Defaults to large.
        /// </summary>
        [QueryParameter("version", DependsOn = new []{ "format=image" })]
        public string? Version { get; set; }
        
        /// <summary>
        /// If true, the returned JSON will be prettified. Avoid using for production code.
        /// </summary>
        [QueryParameter("pretty", DependsOn = new []{ "format=json" })]
        public bool? Pretty { get; set; }
    }
}