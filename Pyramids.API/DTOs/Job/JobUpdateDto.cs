using Pyramids.API.DTOs.JobIssue;
using Pyramids.API.DTOs.JobPart;
using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs
{
    public class JobUpdateDto : EntityBaseDto
    {
        public int? EngineerId { get; set; }
        public int? JobStatusId { get; set; }
        public string? CancelReason { get; set; }
        public int? ClientId { get; set; }
        public int? SiteId { get; set; }
        public int? JobTypeId { get; set; }
        public int? JobSubTypeId { get; set; }
        public int? JobPriorityId { get; set; }
        public string? Description { get; set; }
        public int? EstimatedDuration { get; set; }
        public DateTime? ScheduleDateEnd { get; set; }
        public int? ModifiedByUserId { get; set; }

    }
}
