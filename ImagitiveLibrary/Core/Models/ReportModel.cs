using System;
using System.Collections.Generic;
using System.Text;

namespace ImagitiveLibrary.Core.Models
{
    public class ReportModel
    {
        /// <summary>
        /// Gets or sets the ID of the report.
        /// </summary>
        public int ReportId { get; set; }
        /// <summary>
        /// Gets or sets the ID of the reporter.
        /// </summary>
        public int ReporterId { get; set; }
        /// <summary>
        /// Gets or sets the ID of the artwork being reported.
        /// </summary>
        public int? ArtworkId { get; set; }
        /// <summary>
        /// Gets or sets the reason for the report.
        /// </summary>
        public int ReasonId { get; set; }
        /// <summary>
        /// Gets or sets the description of the report.
        /// </summary>
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// Gets or sets the ID of the user who was reported.
        /// </summary>
        public int? ReportedUserId { get; set; }
        /// <summary>
        /// Gets or sets the status of the report.
        /// </summary>
        public required string Status { get; set; }
        /// <summary>
        /// Gets or sets the date and time when the report was created.
        /// </summary>
        public DateTime ReportedAt { get; set; }
        /// <summary>
        /// Gets or sets the date and time when the report was resolved.
        /// </summary>
        public DateTime? ResolvedAt { get; set; }
        /// <summary>
        /// Gets or sets the ID of the user who resolved the report.
        /// </summary>
        public int? ResolvedBy { get; set; }
        /// <summary>
        /// Gets or sets the action taken regarding the report.
        /// </summary>
        public string? ActionTaken { get; set; }
    }
}
