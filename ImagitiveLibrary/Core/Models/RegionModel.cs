using System;
using System.Collections.Generic;
using System.Text;

namespace ImagitiveLibrary.Core.Models
{
    public class RegionModel
    {
        /// <summary>
        /// Gets or sets the region identifier.
        /// </summary>
        public int RegionId { get; set; }
        /// <summary>
        /// Gets or sets the name of the region.
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
