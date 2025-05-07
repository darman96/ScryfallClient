using System;

namespace ScryfallClient.Models
{
    public class PreviewInfo
    {
        /// <summary>
        /// The date this card was previewed.
        /// </summary>
        public DateTime? PreviewedAt { get; set; }

        /// <summary>
        /// A link to the preview for this card.
        /// </summary>
        public string SourceUri { get; set; } = null!;

        /// <summary>
        /// The name of the source that previewed this card.
        /// </summary>
        public string Source { get; set; } = null!;
    }
}