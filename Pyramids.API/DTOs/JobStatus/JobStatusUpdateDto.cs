using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.JobStatus
{
    public class JobStatusUpdateDto
    {
        public int JobStatusId { get; set; }
        public int? EngineerId { get; set; }
        public string? CancelReason { get; set; }

    }
}
