using System;

namespace ScryfallClient.Models
{
    public class Set : ScryfallObject
    {
        /// <summary>
        /// A unique ID for this set on Scryfall that will not change.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The unique three to six-letter code for this set.
        /// </summary>
        public string Code { get; set; } = null!;

        /// <summary>
        /// The unique code for this set on MTGO, which may differ from the regular code.
        /// </summary>
        public string? MtgoCode { get; set; }

        /// <summary>
        /// The unique code for this set on Arena, which may differ from the regular code.
        /// </summary>
        public string? ArenaCode { get; set; }

        /// <summary>
        /// This set’s ID on TCGplayer’s API, also known as the groupId.
        /// </summary>
        public int? TcgplayerId { get; set; }

        /// <summary>
        /// The English name of the set.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// A computer-readable classification for this set.
        /// </summary>
        public string SetType { get; set; } = null!;

        /// <summary>
        /// The date the set was released or the first card was printed in the set (in GMT-8 Pacific time).
        /// </summary>
        public DateTime? ReleasedAt { get; set; }

        /// <summary>
        /// The block code for this set, if any.
        /// </summary>
        public string? BlockCode { get; set; }

        /// <summary>
        /// The block or group name code for this set, if any.
        /// </summary>
        public string? Block { get; set; }

        /// <summary>
        /// The set code for the parent set, if any.
        /// </summary>
        public string? ParentSetCode { get; set; }

        /// <summary>
        /// The number of cards in this set.
        /// </summary>
        public int CardCount { get; set; }

        /// <summary>
        /// The denominator for the set’s printed collector numbers.
        /// </summary>
        public int? PrintedSize { get; set; }

        /// <summary>
        /// True if this set was only released in a video game.
        /// </summary>
        public bool Digital { get; set; }

        /// <summary>
        /// True if this set contains only foil cards.
        /// </summary>
        public bool FoilOnly { get; set; }

        /// <summary>
        /// True if this set contains only nonfoil cards.
        /// </summary>
        public bool NonfoilOnly { get; set; }

        /// <summary>
        /// A link to this set’s permapage on Scryfall’s website.
        /// </summary>
        public string ScryfallUri { get; set; } = null!;

        /// <summary>
        /// A link to this set object on Scryfall’s API.
        /// </summary>
        public string Uri { get; set; } = null!;

        /// <summary>
        /// A URI to an SVG file for this set’s icon on Scryfall’s CDN.
        /// </summary>
        public string IconSvgUri { get; set; } = null!;

        /// <summary>
        /// A Scryfall API URI that you can request to begin paginating over the cards in this set.
        /// </summary>
        public string SearchUri { get; set; } = null!;
    }
}