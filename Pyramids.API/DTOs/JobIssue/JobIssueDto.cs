using Pyramids.API.DTOs.Asset;
using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.JobIssue
{
    public class JobIssueDto : EntityBaseDto
    {
        public int JobId { get; set; }
        public int JobSessionId { get; set; }
        public string? Description { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool Resolved { get; set; }
        public string? Resolution { get; set; }
        public int? Duration { get; set; }
        public string CreatedOn { get; set; }
        public required string JobIssuePriority { get; set; }
        public JobIssueAssetDto? Asset { get; set; }
    }

    public class JobIssueAssetDto : EntityBaseDto
    {

        public string SerialNo { get; set; }
        public string? TagNo { get; set; }

    }
}
