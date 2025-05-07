using System;

namespace ScryfallClient.Models
{
    public class RelatedCard
    {
        /// <summary>
        /// A unique ID for this card in Scryfall's database.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// A content type for this object, always "related_card".
        /// </summary>
        public string Object { get; set; } = "related_card";

        /// <summary>
        /// A field explaining what role this card plays in this relationship.
        /// </summary>
        /// <remarks>
        /// Possible values: "token", "meld_part", "meld_result", or "combo_piece".
        /// </remarks>
        public string Component { get; set; } = null!;

        /// <summary>
        /// The name of this particular related card.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// The type line of this card.
        /// </summary>
        public string TypeLine { get; set; } = null!;

        /// <summary>
        /// A URI where you can retrieve a full object describing this card on Scryfall's API.
        /// </summary>
        public string Uri { get; set; } = null!;
    }
}