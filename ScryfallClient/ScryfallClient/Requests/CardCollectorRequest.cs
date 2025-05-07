using ScryfallClient.Attributes;
using ScryfallClient.Requests.Interfaces;

namespace ScryfallClient.Requests
{
    public class CardCollectorRequest : IRequest
    {
        public string EndpointUri => "cards/<code>/<number>/<?lang>";
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
        /// The 2-3 character language code.
        /// </summary>
        [QueryParameter("lang" , IsPartOfPath = true)]
        public string? Lang { get; set; }

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