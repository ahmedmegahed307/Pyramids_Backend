using Pyramids.API.DTOs.Asset;
using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.JobIssue
{
    public class JobIssueUpdateDto : EntityBaseDto
    {
        public  int? JobId { get; set; }
        public  int? JobSessionId { get; set; }
        public string? Description { get; set; }
        public int? AssetId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? Resolved { get; set; }
        public string? Resolution { get; set; }
        public int? Duration { get; set; }
        public  string? CreatedOn { get; set; }
        public  string? JobIssuePriority { get; set; }
    }
}
