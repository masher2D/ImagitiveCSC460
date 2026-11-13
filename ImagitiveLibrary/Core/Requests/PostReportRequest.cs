using System;
using System.Collections.Generic;
using System.Text;

namespace ImagitiveLibrary.Core.Requests
{
    public class PostReportRequest
    {
        
        /// <summary>
        /// Gets or sets the ID of the artwork being reported.
        /// </summary>
        public int? ArtworkId { get; set; }
        /// <summary>
        /// Gets or sets the ID of the user being reported.
        /// </summary>
        public int? ReportedUserId { get; set; }
        /// <summary>
        /// Gets or sets the reason for the report.
        /// </summary>
        public int ReasonId { get; set; }
        /// <summary>
        /// Gets or sets the description of the report.
        /// </summary>
        public string Description { get; set; } = string.Empty;
    }
}
