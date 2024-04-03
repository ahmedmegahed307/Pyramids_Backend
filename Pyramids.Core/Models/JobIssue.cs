using Pyramids.Shared.Entity;

namespace Pyramids.Core.Models
{
    public class JobIssue : EntityBase,IActiveEntity
    {
        public int JobId { get; set; }
        public int? JobSessionId { get; set; }
        public int? AssetId { get; set; }
        public string? Description { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? Resolved { get; set; }
        public string? Resolution { get; set; }
        public int? Duration { get; set; }
        public  string? CreatedOn { get; set; } = "admin";
        public  string? JobIssuePriority { get; set; }
        public virtual Asset? Asset { get; set; }
        public virtual Job? Job { get; set; }
    }
}
