using System.Collections.Generic;

namespace ScryfallClient.Models
{
    public class Error : ScryfallObject
    {
        /// <summary>
        /// An integer HTTP status code for this error.
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// A computer-friendly string representing the appropriate HTTP status code.
        /// </summary>
        public string Code { get; set; } = null!;

        /// <summary>
        /// A human-readable string explaining the error.
        /// </summary>
        public string Details { get; set; } = null!;

        /// <summary>
        /// A computer-friendly string that provides additional context for the main error.
        /// </summary>
        public string? Type { get; set; }

        /// <summary>
        /// Non-failure warnings as human-readable strings.
        /// </summary>
        public List<string>? Warnings { get; set; }
    }
}