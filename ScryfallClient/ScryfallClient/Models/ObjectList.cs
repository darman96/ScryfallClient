using System;
using System.Collections.Generic;

namespace ScryfallClient.Models
{
    public class ObjectList<T> : ScryfallObject where T : ScryfallObject
    {
        /// <summary>
        /// An array of the requested objects, in a specific order.
        /// </summary>
        public List<T> Data { get; set; } = new List<T>();

        /// <summary>
        /// True if this List is paginated and there is a page beyond the current page.
        /// </summary>
        public bool HasMore { get; set; }

        /// <summary>
        /// If there is a page beyond the current page, this field will contain a full API URI to that page.
        /// </summary>
        public Uri? NextPage { get; set; }

        /// <summary>
        /// Total number of cards found across all pages.
        /// </summary>
        public int? TotalCards { get; set; }

        /// <summary>
        /// An array of human-readable warnings issued when generating this list.
        /// </summary>
        public List<string> Warnings { get; set; } = new List<string>();
    }
}