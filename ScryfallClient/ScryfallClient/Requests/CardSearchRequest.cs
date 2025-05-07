using ScryfallClient.Attributes;
using ScryfallClient.Enums;
using ScryfallClient.Requests.Interfaces;

namespace ScryfallClient.Requests
{
    public class CardSearchRequest : IRequest
    {
        public string EndpointUri => "cards/search";
        public string Method => "GET";
        
        /// <summary>
        /// A fulltext search query. Make sure that your parameter is properly encoded.
        /// Maximum length: 1000 Unicode characters.
        /// </summary>
        [QueryParameter("q")]
        public string Query { get; set; } = null!;
        
        /// <summary>
        /// The strategy for omitting similar cards.
        /// </summary>
        [QueryParameter("unique")]
        public UniqueMode? Unique { get; set; }
        
        /// <summary>
        /// The method to sort returned cards.
        /// </summary>
        [QueryParameter("order")]
        public OrderMode? Order { get; set; }
        
        /// <summary>
        /// The direction to sort cards.
        /// </summary>
        [QueryParameter("dir")]
        public OrderDirection? Direction { get; set; }
        
        /// <summary>
        /// If true, extra cards (tokens, planes, etc) will be included.
        /// Equivalent to adding include:extras to the fulltext search.
        /// Defaults to false.
        /// </summary>
        [QueryParameter("include_extras")]
        public bool? IncludeExtras { get; set; }
        
        /// <summary>
        /// If true, cards in every language supported by Scryfall will be included.
        /// Defaults to false.
        /// </summary>
        [QueryParameter("include_multilingual")]
        public bool? IncludeMultilingual { get; set; }
        
        /// <summary>
        /// If true, rare care variants will be included, like the Hairy Runesword.
        /// Defaults to false.
        /// </summary>
        [QueryParameter("include_variations")]
        public bool? IncludeVariations { get; set; }
        
        /// <summary>
        /// The page number to return, default 1.
        /// </summary>
        [QueryParameter("page")]
        public int? Page { get; set; }

        /// <summary>
        /// The data format to return: json or csv.
        /// Defaults to json.
        /// </summary>
        [QueryParameter("format")]
        public string Format { get; set; } = "json";
        
        /// <summary>
        /// If true, the returned JSON will be prettified. Avoid using for production code.
        /// </summary>
        [QueryParameter("pretty", DependsOn = new []{ "format=json" })]
        public bool? Pretty { get; set; }
    }
}