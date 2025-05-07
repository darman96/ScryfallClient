using System;
using System.Collections.Generic;

namespace ScryfallClient.Models
{
    public class Card : ScryfallObject
    {
        /// <summary>
        /// This card's Arena ID, if any. A large percentage of cards are not available on Arena and do not have this ID.
        /// </summary>
        public int? ArenaId { get; set; }

        /// <summary>
        /// A unique ID for this card in Scryfall's database.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// A language code for this printing.
        /// </summary>
        public string Lang { get; set; } = null!;

        /// <summary>
        /// This card's Magic Online ID (also known as the Catalog ID), if any.
        /// </summary>
        public int? MtgoId { get; set; }

        /// <summary>
        /// This card's foil Magic Online ID (also known as the Catalog ID), if any.
        /// </summary>
        public int? MtgoFoilId { get; set; }

        /// <summary>
        /// This card's multiverse IDs on Gatherer, if any, as an array of integers.
        /// </summary>
        public List<int> MultiverseIds { get; set; } = new List<int>();

        /// <summary>
        /// This card's ID on TCGplayer's API, also known as the productId.
        /// </summary>
        public int? TcgplayerId { get; set; }

        /// <summary>
        /// This card's ID on TCGplayer's API, for its etched version if that version is a separate product.
        /// </summary>
        public int? TcgplayerEtchedId { get; set; }

        /// <summary>
        /// This card's ID on Cardmarket's API, also known as the idProduct.
        /// </summary>
        public int? CardmarketId { get; set; }

        /// <summary>
        /// A code for this card's layout.
        /// </summary>
        public string Layout { get; set; } = null!;

        /// <summary>
        /// A unique ID for this card's oracle identity.
        /// </summary>
        public Guid? OracleId { get; set; }

        /// <summary>
        /// A link to where you can begin paginating all reprints for this card on Scryfall's API.
        /// </summary>
        public string PrintsSearchUri { get; set; } = null!;

        /// <summary>
        /// A link to this card's rulings list on Scryfall's API.
        /// </summary>
        public string RulingsUri { get; set; } = null!;

        /// <summary>
        /// A link to this card's permapage on Scryfall's website.
        /// </summary>
        public string ScryfallUri { get; set; } = null!;

        /// <summary>
        /// A link to this card object on Scryfall's API.
        /// </summary>
        public string Uri { get; set; } = null!;

        /// <summary>
        /// If this card is closely related to other cards, this property will be an array with Related Card Objects.
        /// </summary>
        public List<RelatedCard> AllParts { get; set; } = new List<RelatedCard>();

        /// <summary>
        /// An array of Card Face objects, if this card is multifaceted.
        /// </summary>
        public List<CardFace> CardFaces { get; set; } = new List<CardFace>();

        /// <summary>
        /// The card's mana value. Note that some funny cards have fractional mana costs.
        /// </summary>
        public decimal Cmc { get; set; }

        /// <summary>
        /// This card's color identity.
        /// </summary>
        public List<string> ColorIdentity { get; set; } = new List<string>();

        /// <summary>
        /// The colors in this card's color indicator, if any.
        /// </summary>
        public List<string> ColorIndicator { get; set; } = new List<string>();

        /// <summary>
        /// This card's colors, if the overall card has colors defined by the rules.
        /// </summary>
        public List<string> Colors { get; set; } = new List<string>();

        /// <summary>
        /// This face's defense, if any.
        /// </summary>
        public string Defense { get; set; } = null!;

        /// <summary>
        /// This card's overall rank/popularity on EDHREC. Not all cards are ranked.
        /// </summary>
        public int? EdhrecRank { get; set; }

        /// <summary>
        /// True if this card is on the Commander Game Changer list.
        /// </summary>
        public bool GameChanger { get; set; }

        /// <summary>
        /// This card's hand modifier, if it is Vanguard card.
        /// </summary>
        public string HandModifier { get; set; } = null!;

        /// <summary>
        /// An array of keywords that this card uses.
        /// </summary>
        public List<string> Keywords { get; set; } = new List<string>();

        /// <summary>
        /// An object describing the legality of this card across play formats.
        /// </summary>
        public Dictionary<string, string> Legalities { get; set; } = new Dictionary<string, string>();
        
        /// <summary>
        /// This card's life modifier, if it is Vanguard card.
        /// </summary>
        public string LifeModifier { get; set; } = null!;

        /// <summary>
        /// This loyalty if any. Note that some cards have loyalties that are not numeric.
        /// </summary>
        public string Loyalty { get; set; } = null!;

        /// <summary>
        /// The mana cost for this card.
        /// </summary>
        public string ManaCost { get; set; } = null!;

        /// <summary>
        /// The name of this card.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// The Oracle text for this card, if any.
        /// </summary>
        public string OracleText { get; set; } = null!;

        /// <summary>
        /// This card's rank/popularity on Penny Dreadful.
        /// </summary>
        public int? PennyRank { get; set; }

        /// <summary>
        /// This card's power, if any.
        /// </summary>
        public string Power { get; set; } = null!;

        /// <summary>
        /// Colors of mana that this card could produce.
        /// </summary>
        public List<string> ProducedMana { get; set; } = new List<string>();

        /// <summary>
        /// True if this card is on the Reserved List.
        /// </summary>
        public bool Reserved { get; set; }

        /// <summary>
        /// This card's toughness, if any.
        /// </summary>
        public string Toughness { get; set; } = null!;

        /// <summary>
        /// The type line of this card.
        /// </summary>
        public string TypeLine { get; set; } = null!;

        /// <summary>
        /// The name of the illustrator of this card.
        /// </summary>
        public string Artist { get; set; } = null!;

        /// <summary>
        /// The IDs of the artists that illustrated this card.
        /// </summary>
        public List<Guid> ArtistIds { get; set; } = new List<Guid>();

        /// <summary>
        /// The lit Unfinity attractions lights on this card, if any.
        /// </summary>
        public List<string> AttractionLights { get; set; } = new List<string>();

        /// <summary>
        /// Whether this card is found in boosters.
        /// </summary>
        public bool Booster { get; set; }

        /// <summary>
        /// This card's border color: black, white, borderless, yellow, silver, or gold.
        /// </summary>
        public string BorderColor { get; set; } = null!;

        /// <summary>
        /// The Scryfall ID for the card back design present on this card.
        /// </summary>
        public Guid CardBackId { get; set; }

        /// <summary>
        /// This card's collector number.
        /// </summary>
        public string CollectorNumber { get; set; } = null!;

        /// <summary>
        /// True if you should consider avoiding use of this print downstream.
        /// </summary>
        public bool ContentWarning { get; set; }

        /// <summary>
        /// True if this card was only released in a video game.
        /// </summary>
        public bool Digital { get; set; }

        /// <summary>
        /// An array of computer-readable flags that indicate if this card can come in foil, nonfoil, or etched finishes.
        /// </summary>
        public List<string> Finishes { get; set; } = new List<string>();

        /// <summary>
        /// The just-for-fun name printed on the card (such as for Godzilla series cards).
        /// </summary>
        public string FlavorName { get; set; } = null!;

        /// <summary>
        /// The flavor text, if any.
        /// </summary>
        public string FlavorText { get; set; } = null!;

        /// <summary>
        /// This card's frame effects, if any.
        /// </summary>
        public List<string> FrameEffects { get; set; } = new List<string>();

        /// <summary>
        /// This card's frame layout.
        /// </summary>
        public string Frame { get; set; } = null!;

        /// <summary>
        /// True if this card's artwork is larger than normal.
        /// </summary>
        public bool FullArt { get; set; }

        /// <summary>
        /// A list of games that this card print is available in: paper, arena, and/or mtgo.
        /// </summary>
        public List<string> Games { get; set; } = new List<string>();

        /// <summary>
        /// True if this card's imagery is high resolution.
        /// </summary>
        public bool HighresImage { get; set; }

        /// <summary>
        /// A unique identifier for the card artwork that remains consistent across reprints.
        /// </summary>
        public Guid? IllustrationId { get; set; }

        /// <summary>
        /// A computer-readable indicator for the state of this card's image.
        /// </summary>
        public string ImageStatus { get; set; } = null!;

        /// <summary>
        /// An object listing available imagery for this card.
        /// </summary>
        public Dictionary<string, string> ImageUris { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// True if this card is oversized.
        /// </summary>
        public bool Oversized { get; set; }

        /// <summary>
        /// An object containing daily price information for this card.
        /// </summary>
        public Dictionary<string, string> Prices { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// The localized name printed on this card, if any.
        /// </summary>
        public string PrintedName { get; set; } = null!;

        /// <summary>
        /// The localized text printed on this card, if any.
        /// </summary>
        public string PrintedText { get; set; } = null!;

        /// <summary>
        /// The localized type line printed on this card, if any.
        /// </summary>
        public string PrintedTypeLine { get; set; } = null!;

        /// <summary>
        /// True if this card is a promotional print.
        /// </summary>
        public bool Promo { get; set; }

        /// <summary>
        /// An array of strings describing what categories of promo cards this card falls into.
        /// </summary>
        public List<string> PromoTypes { get; set; } = new List<string>();

        /// <summary>
        /// An object providing URIs to this card's listing on major marketplaces.
        /// </summary>
        public Dictionary<string, string> PurchaseUris { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// This card's rarity.
        /// </summary>
        public string Rarity { get; set; } = null!;

        /// <summary>
        /// An object providing URIs to this card's listing on other Magic: The Gathering online resources.
        /// </summary>
        public Dictionary<string, string> RelatedUris { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// The date this card was first released.
        /// </summary>
        public DateTime? ReleasedAt { get; set; }

        /// <summary>
        /// True if this card is a reprint.
        /// </summary>
        public bool Reprint { get; set; }

        /// <summary>
        /// A link to this card's set on Scryfall's website.
        /// </summary>
        public string ScryfallSetUri { get; set; } = null!;

        /// <summary>
        /// This card's full set name.
        /// </summary>
        public string SetName { get; set; } = null!;

        /// <summary>
        /// A link to where you can begin paginating this card's set on the Scryfall API.
        /// </summary>
        public string SetSearchUri { get; set; } = null!;

        /// <summary>
        /// The type of set this printing is in.
        /// </summary>
        public string SetType { get; set; } = null!;

        /// <summary>
        /// A link to this card's set object on Scryfall's API.
        /// </summary>
        public string SetUri { get; set; } = null!;

        /// <summary>
        /// This card's set code.
        /// </summary>
        public string Set { get; set; } = null!;

        /// <summary>
        /// This card's Set object UUID.
        /// </summary>
        public Guid SetId { get; set; }

        /// <summary>
        /// True if this card is a Story Spotlight.
        /// </summary>
        public bool StorySpotlight { get; set; }

        /// <summary>
        /// True if the card is printed without text.
        /// </summary>
        public bool Textless { get; set; }

        /// <summary>
        /// Whether this card is a variation of another printing.
        /// </summary>
        public bool Variation { get; set; }

        /// <summary>
        /// The printing ID of the printing this card is a variation of.
        /// </summary>
        public Guid? VariationOf { get; set; }

        /// <summary>
        /// The security stamp on this card, if any.
        /// </summary>
        public string SecurityStamp { get; set; } = null!;

        /// <summary>
        /// This card's watermark, if any.
        /// </summary>
        public string Watermark { get; set; } = null!;

        /// <summary>
        /// Preview information for this card.
        /// </summary>
        public PreviewInfo Preview { get; set; } = null!;
    }
}