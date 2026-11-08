using System;
using System.Collections.Generic;
using System.Text;

namespace ImagitiveLibrary.Core.Requests
{

    public class PostRatingRequest
    {
        
        /// <summary>
        /// The ID of the artwork being rated.
        /// </summary>
        public int ArtworkId { get; set; }
        /// <summary>
        /// The rating value being submitted (e.g., 1-5).
        /// </summary>
        public byte RateValue { get; set; }
    }
}
