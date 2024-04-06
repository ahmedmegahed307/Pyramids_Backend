using Pyramids.API.DTOs.Asset;
using Pyramids.API.DTOs.Client.Contact;
using Pyramids.API.DTOs.Client.Site;
using Pyramids.API.DTOs.JobAction;
using Pyramids.API.DTOs.JobAttachment;
using Pyramids.API.DTOs.JobIssue;
using Pyramids.API.DTOs.JobPart;
using Pyramids.API.DTOs.Priority;
using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.Job
{
    public class JobDto : EntityBaseDto
    {
        public int CompanyId { get; set; }
        public int? ClientId { get; set; }
        public int? SiteId { get; set; }
        public int? ContactId { get; set; }
        public int? JobTypeId { get; set; }
        public int? JobSubTypeId { get; set; }
        public string? Description { get; set; }
        public int? EngineerId { get; set; }
        public string? TechComments { get; set; }
        public string? CancelReason { get; set; }

        public int? JobStatusId { get; set; }
        public int? PriorityId { get; set; }

        public DateTime? JobDate { get; set; }
        public DateTime? ScheduleDateEnd { get; set; }
        public DateTime? AssignedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? EstimatedDuration { get; set; }
        public JobJobTypeDto JobType { get; set; }
        public JobClientDto Client { get; set; }
        public JobContactDto Contact { get; set; }
        public JobSiteDto Site { get; set; }
        public PriorityDto Priority { get; set; }
        public JobJobSubTypeDto JobSubType { get; set; }
        public JobUserDto Engineer { get; set; }
        public JobStatusDto JobStatus { get; set; }
        public List<JobPartDto> JobParts { get; set; }
        public List<JobActionDto> JobActions { get; set; }
        public List<JobJobIssueDto> JobIssues { get; set; }
        public List<JobAttachmentDto> JobAttachments { get; set; }


    }
    public class JobClientDto : EntityBaseDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
    public class JobContactDto : EntityBaseDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }



    public class JobSiteDto : EntityBaseDto
    {
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
    }
  
    public class JobJobTypeDto : EntityBaseDto
    {
        public string Name { get; set; }

    }
    public class JobJobSubTypeDto : EntityBaseDto
    {
        public string Name { get; set; }
    }
    public class JobUserDto : EntityBaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class JobStatusDto : EntityBaseDto
    {
        public string Name { get; set; }
        public char Code { get; set; }
    }
    public class JobJobIssueDto : EntityBaseDto
    {
        public int JobId { get; set; }
        public JobIssueAssetDto? Asset { get; set; }
        public string? Description { get; set; }
        public string? JobIssuePriority { get; set; }
    }

}
