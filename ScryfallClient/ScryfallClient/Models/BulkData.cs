using System;

namespace ScryfallClient.Models
{
    public class BulkData : ScryfallObject
    {
        /// <summary>
        /// A unique ID for this bulk item.
        /// </summary>
        public Guid Id { get; set; } = default!;

        /// <summary>
        /// The Scryfall API URI for this file.
        /// </summary>
        public string Uri { get; set; } = null!;

        /// <summary>
        /// A computer-readable string for the kind of bulk item.
        /// </summary>
        public string Type { get; set; } = null!;

        /// <summary>
        /// A human-readable name for this file.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// A human-readable description for this file.
        /// </summary>
        public string Description { get; set; } = null!;

        /// <summary>
        /// The URI that hosts this bulk file for fetching.
        /// </summary>
        public string DownloadUri { get; set; } = null!;

        /// <summary>
        /// The time when this file was last updated.
        /// </summary>
        public DateTime UpdatedAt { get; set; } = default!;

        /// <summary>
        /// The size of this file in integer bytes.
        /// </summary>
        public long Size { get; set; } = default!;

        /// <summary>
        /// The MIME type of this file.
        /// </summary>
        public string ContentType { get; set; } = null!;

        /// <summary>
        /// The Content-Encoding encoding that will be used to transmit this file when you download it.
        /// </summary>
        public string ContentEncoding { get; set; } = null!;
    }
}
