using Pyramids.API.DTOs.Job;
using Pyramids.API.DTOs.JobIssue;
using Pyramids.API.DTOs.JobPart;
using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs
{
    public class JobCreateDto : EntityBaseDto
    {
        public int CompanyId { get; set; }
        public int ClientId { get; set; }
        public int? SiteId { get; set; }
        public int? ContactId { get; set; }
        public int? JobTypeId { get; set; }
        public int? JobSubTypeId { get; set; }
        public string? Description { get; set; }
        public int? EngineerId { get; set; }
        public string? TechComments { get; set; }
        public int JobStatusId { get; set; }
        public int JobPriorityId { get; set; }
        public DateTime? ScheduleDateEnd { get; set; }
        public int? EstimatedDuration { get; set; }
        public int CreatedByUserId { get; set; }
        public ICollection<JobIssueCreateDto>? JobIssueCreateDto { get; set; }
        public ICollection<JobCreateJobPart>? JobParts { get; set; }
        // public ICollection<JobPartDto>? JobParts { get; set; }
        public List<IFormFile>? FilesToUpload { get; set; }

    }

    public class JobCreateJobPart
    {
        public required int Id { get; set; }
        public required int Quantity { get; set; }
        public required int ProductId { get; set; }
    }
}
