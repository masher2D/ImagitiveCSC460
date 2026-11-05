using System;
using System.Collections.Generic;
using System.Text;

namespace ImagitiveLibrary.Core.Requests
{
    public class CreateReportRequest
    {
        /// <summary>
        /// Gets or sets the ID of the report.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the ID of the reporter.
        /// </summary>
        public int ReporterId { get; set; }
        /// <summary>
        /// Gets or sets the ID of the artwork being reported.
        /// </summary>
        public int ArtworkId { get; set; }
        /// <summary>
        /// Gets or sets the reason for the report.
        /// </summary>
        public int ReasonID { get; set; }
        /// <summary>
        /// Gets or sets the description of the report.
        /// </summary>
        public string Description { get; set; } = string.Empty;
    }
}
