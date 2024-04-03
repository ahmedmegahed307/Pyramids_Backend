using Pyramids.Shared.Entity;

namespace Pyramids.Core.Models
{
    public class Job : EntityBase, ICompanyEntity,IActiveEntity
    {
        public Job()
        {
            JobIssues = new HashSet<JobIssue>();
            JobParts = new HashSet<JobPart>();
            JobActions = new HashSet<JobAction>();
            JobAttachments = new HashSet<JobAttachment>();
            JobSessions = new HashSet<JobSession>();
            Reminders = new HashSet<Reminder>();
            Visit = new HashSet<Visit>();
        }
        public int CompanyId { get; set; }
        public int? ClientId { get; set; }
        public int? ContactId { get; set; }
        public int? JobStatusId{ get; set; }
        public int? JobTypeId { get; set; }
        public DateTime? JobDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? EstimatedDuration { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string? CancelReason { get; set; }
        public string? Description { get; set; }
        public int? PriorityId { get; set; }
        public DateTime? ScheduleDateEnd { get; set; }
        public bool? NotifyClient { get; set; }
        public bool? CashOnDelivery { get; set; }
        public Guid? UniqueCode { get; set; }
        public bool? GetSurveySignature { get; set; }
        public bool? IsGenerated { get; set; }
        public string? Instruction { get; set; }
        public string? JobContact { get; set; }
        public string? JobAddress { get; set; }
        public int? AddressId { get; set; }
        public int? SiteId { get; set; }
        public int? EngineerId { get; set; }
        public string? TechComments { get; set; }
        public int? JobSubTypeId { get; set; }

        public User CreatedByUser { get; set; } 
        public JobStatus JobStatus { get; set; }
        public Priority Priority { get; set; }
        public Company Company { get; set; }
        public Client Client { get; set; }
        public Site Site { get; set; }
        public Address Address { get; set; }
        public User Engineer { get; set; }
        public JobType JobType { get; set; }
        public JobSubType JobSubType { get; set; }
        public Contact Contact { get; set; }
        public virtual ICollection<JobIssue> JobIssues { get; set; }
        public virtual ICollection<JobPart> JobParts { get; set; }
        public virtual ICollection<JobAction> JobActions { get; set; }
        public virtual ICollection<JobAttachment> JobAttachments { get; set; }
        public virtual  ICollection<JobSession> JobSessions { get; set; }
        public virtual ICollection<Reminder> Reminders { get; set; }
        public virtual ICollection<Visit> Visit { get; set; }


    }
}
