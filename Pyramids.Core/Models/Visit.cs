using Pyramids.Shared.Entity;

namespace Pyramids.Core.Models
{
    public class Visit : EntityBase, IActiveEntity
    {
        public Visit()
        {
            Reminders = new HashSet<Reminder>();
        }
        public int? ContractId { get; set; }
        public bool? IsGenerated { get; set; }
        public DateTime? VisitDate { get; set; }
        public bool? Invoiced { get; set; }
        public int? JobId { get; set; }
        public DateTime? GeneratedDate { get; set; }
        public int? GeneratedByUserId { get; set; }
        public virtual Job Job { get; set; }

        public virtual User GeneratedByUser { get; set; }
        public virtual Contract Contract { get; set; }
        public virtual ICollection<Reminder> Reminders { get; set; }
    }
}
