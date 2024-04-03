using Pyramids.Shared.Entity;

namespace Pyramids.Core.Models
{
    public class Contract : EntityBase,IActiveEntity
    {

        public Contract()
        {
           
            Visits = new HashSet<Visit>();
            Reminders = new HashSet<Reminder>();
        }
        public string? ContractRef { get; set; }
        public string? Description { get; set; }
        public int? ClientId { get; set; }
        public int? JobTypeId { get; set; }
        public int? JobSubTypeId { get; set; }
        public string? Status { get; set; }
        public int? DefaultEngineerId { get; set; }
        
        public int? FrequencyType { get; set; }
        public int? FrequencyCount { get; set; }
        public string? BillingType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? NextVisitDate { get; set; }
        public int? EstimatedDurationMinutes { get; set; }
        public double? ContractCharge { get; set; }
        public User CreatedByUser { get; set; }
        public virtual Client Client { get; set; }
        public virtual User DefaultEngineer { get; set; }
        public virtual JobType JobType { get; set; }
        public virtual JobSubType JobSubType { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
        public virtual ICollection<Reminder> Reminders { get; set; }

    }
}
