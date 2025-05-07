using System.Collections.Generic;

namespace ScryfallClient.Models
{
    public class Catalog : ScryfallObject
    {
        /// <summary>
        /// A link to the current catalog on Scryfall's API.
        /// </summary>
        public string Uri { get; set; } = null!;

        /// <summary>
        /// The number of items in the data array.
        /// </summary>
        public int TotalValues { get; set; }

        /// <summary>
        /// An array of datapoints, as strings.
        /// </summary>
        /// <remarks>
        /// The contents of this array depend on the specific catalog being requested.
        /// Common catalog types include card names, artist names, word bank entries, etc.
        /// </remarks>
        public List<string> Data { get; set; } = new List<string>();
    }
}