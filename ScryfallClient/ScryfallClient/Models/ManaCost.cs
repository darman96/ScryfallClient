using System.Collections.Generic;

namespace ScryfallClient.Models
{
    /// <summary>
    /// Represents a parsed mana cost.
    /// </summary>
    public class ManaCost : ScryfallObject
    {
        /// <summary>
        /// The normalized cost, with correctly-ordered and wrapped mana symbols.
        /// </summary>
        public string Cost { get; set; } = null!;

        /// <summary>
        /// The mana value. If you submit Un-set mana symbols, this decimal could include fractional parts.
        /// </summary>
        public decimal Cmc { get; set; }

        /// <summary>
        /// The colors of the given cost.
        /// </summary>
        public List<string> Colors { get; set; } = new List<string>();

        /// <summary>
        /// True if the cost is colorless.
        /// </summary>
        public bool Colorless { get; set; }

        /// <summary>
        /// True if the cost is monocolored.
        /// </summary>
        public bool Monocolored { get; set; }

        /// <summary>
        /// True if the cost is multicolored.
        /// </summary>
        public bool Multicolored { get; set; }
    }
}
