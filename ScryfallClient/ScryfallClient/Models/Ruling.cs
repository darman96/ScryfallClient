using System;

namespace ScryfallClient.Models
{
    public class Ruling : ScryfallObject
    {
        /// <summary>
        /// The Oracle ID of the card this ruling is associated with.
        /// </summary>
        public Guid OracleId { get; set; }

        /// <summary>
        /// A computer-readable string indicating which company produced this ruling, either wotc or scryfall.
        /// </summary>
        public string Source { get; set; } = null!;

        /// <summary>
        /// The date when the ruling or note was published.
        /// </summary>
        public DateTime PublishedAt { get; set; }

        /// <summary>
        /// The text of the ruling.
        /// </summary>
        public string Comment { get; set; } = null!;
    }
}
