using System;
using System.Collections.Generic;
using System.Text;

namespace ImagitiveLibrary.Core.Responses
{
    public class PostRatingResponse
    {
        /// <summary>
        /// Gets or sets a value indicating whether the operation completed successfully.
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// The error message associated with the response, if any.
        /// </summary>
        public string? ErrorMessage { get; set; }
        /// <summary>
        /// The updated average rating value after the rating has been posted, if applicable.
        /// </summary>
        public double? AverageRating { get; set; }
    }
}
