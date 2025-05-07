using System;
using System.Collections.Generic;

namespace ScryfallClient.Models
{
    public class CardFace : ScryfallObject
    {
        /// <summary>
    /// The name of the illustrator of this card face.
    /// </summary>
    public string Artist { get; set; } = null!;

    /// <summary>
    /// The ID of the illustrator of this card face.
    /// </summary>
    public Guid? ArtistId { get; set; }

    /// <summary>
    /// The mana value of this particular face, if the card is reversible.
    /// </summary>
    public decimal Cmc { get; set; }

    /// <summary>
    /// The colors in this face's color indicator, if any.
    /// </summary>
    public List<string> ColorIndicator { get; set; } = new List<string>(); 

    /// <summary>
    /// This face's colors, if the game defines colors for the individual face of this card.
    /// </summary>
    public List<string> Colors { get; set; } = new List<string>();

    /// <summary>
    /// This face's defense, if any.
    /// </summary>
    public string Defense { get; set; } = null!;

    /// <summary>
    /// The flavor text printed on this face, if any.
    /// </summary>
    public string FlavorText { get; set; } = null!;

    /// <summary>
    /// A unique identifier for the card face artwork that remains consistent across reprints.
    /// </summary>
    public Guid? IllustrationId { get; set; }

    /// <summary>
    /// An object providing URIs to imagery for this face, if this is a double-sided card.
    /// </summary>
    public Dictionary<string, string> ImageUris { get; set; } = new Dictionary<string, string>();

    /// <summary>
    /// The layout of this card face, if the card is reversible.
    /// </summary>
    public string Layout { get; set; } = null!;

    /// <summary>
    /// This face's loyalty, if any.
    /// </summary>
    public string Loyalty { get; set; } = null!;

    /// <summary>
    /// The mana cost for this face. This value will be any empty string "" if the cost is absent.
    /// </summary>
    public string ManaCost { get; set; } = null!;

    /// <summary>
    /// The name of this particular face.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// The Oracle ID of this particular face, if the card is reversible.
    /// </summary>
    public Guid? OracleId { get; set; }

    /// <summary>
    /// The Oracle text for this face, if any.
    /// </summary>
    public string OracleText { get; set; } = null!;

    /// <summary>
    /// This face's power, if any. Note that some cards have powers that are not numeric.
    /// </summary>
    public string Power { get; set; } = null!;

    /// <summary>
    /// The localized name printed on this face, if any.
    /// </summary>
    public string PrintedName { get; set; } = null!;

    /// <summary>
    /// The localized text printed on this face, if any.
    /// </summary>
    public string PrintedText { get; set; } = null!;

    /// <summary>
    /// The localized type line printed on this face, if any.
    /// </summary>
    public string PrintedTypeLine { get; set; } = null!;

    /// <summary>
    /// This face's toughness, if any.
    /// </summary>
    public string Toughness { get; set; } = null!;

    /// <summary>
    /// The type line of this particular face, if the card is reversible.
    /// </summary>
    public string TypeLine { get; set; } = null!;

    /// <summary>
    /// The watermark on this particular card face, if any.
    /// </summary>
    public string Watermark { get; set; } = null!;
    }
}