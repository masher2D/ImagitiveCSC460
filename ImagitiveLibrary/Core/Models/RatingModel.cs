using System;
using System.Collections.Generic;
using System.Text;

namespace ImagitiveLibrary.Core.Models
{
    public class RatingModel
    {
        /// <summary>
        /// Gets or sets the ID of the user who rated the artwork.
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Gets or sets the ID of the artwork being rated.
        /// </summary>
        public int ArtworkId { get; set; }
        /// <summary>
        /// Gets or sets the rating given by the user.
        /// </summary>
        public int Rating { get; set; }



    }
}
