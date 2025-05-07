using System.Collections.Generic;

namespace ScryfallClient.Models
{
    public class CardSymbol : ScryfallObject
    {
    /// <summary>
    /// The plaintext symbol. Often surrounded with curly braces {}.
    /// </summary>
    /// <remarks>
    /// Note that not all symbols are ASCII text (for example, `[o]`).
    /// </remarks>
    public string Symbol { get; set; } = null!;

    /// <summary>
    /// An alternate version of this symbol, if it is possible to write it without curly braces.
    /// </summary>
    public string LooseVariant { get; set; } = null!;

    /// <summary>
    /// An English snippet that describes this symbol.
    /// </summary>
    /// <remarks>
    /// Appropriate for use in alt text or other accessible communication formats.
    /// </remarks>
    public string English { get; set; } = null!;

    /// <summary>
    /// True if it is possible to write this symbol "backwards".
    /// </summary>
    /// <remarks>
    /// For example, the official symbol `{U/P}` is sometimes written as `{P/U}` or `{P\U}`.
    /// Note that the Scryfall API never writes symbols backwards in other responses.
    /// </remarks>
    public bool Transposable { get; set; }

    /// <summary>
    /// True if this is a mana symbol.
    /// </summary>
    public bool RepresentsMana { get; set; }

    /// <summary>
    /// A decimal number representing this symbol's mana value (converted mana cost).
    /// </summary>
    /// <remarks>
    /// Note that mana symbols from funny sets can have fractional mana values.
    /// </remarks>
    public decimal? ManaValue { get; set; }

    /// <summary>
    /// True if this symbol appears in a mana cost on any Magic card.
    /// </summary>
    /// <remarks>
    /// For example `{20}` has this field set to `false` because it only appears in Oracle text.
    /// </remarks>
    public bool AppearsInManaCosts { get; set; }

    /// <summary>
    /// True if this symbol is only used on funny cards or Un-cards.
    /// </summary>
    public bool Funny { get; set; }

    /// <summary>
    /// An array of colors that this symbol represents.
    /// </summary>
    public List<string> Colors { get; set; } = new List<string>();

    /// <summary>
    /// True if the symbol is a hybrid mana symbol.
    /// </summary>
    /// <remarks>
    /// Note that monocolor Phyrexian symbols aren't considered hybrid.
    /// </remarks>
    public bool Hybrid { get; set; }

    /// <summary>
    /// True if the symbol is a Phyrexian mana symbol (can be paid with 2 life).
    /// </summary>
    public bool Phyrexian { get; set; }

    /// <summary>
    /// An array of plaintext versions of this symbol that Gatherer uses on old cards.
    /// </summary>
    /// <remarks>
    /// For example: `{W}` has `["OW", "OW"]` as alternates.
    /// </remarks>
    public List<string> GathererAlternates { get; set; } = new List<string>();

    /// <summary>
    /// A URI to an SVG image of this symbol on Scryfall's CDNs.
    /// </summary>
    public string SvgUri { get; set; } = null!;
    }
}