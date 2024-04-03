using Pyramids.Shared.Entity;

namespace Pyramids.Core.Models
{
    public class Reminder:EntityBase,IActiveEntity
    {
        public Reminder()
        {
            this.ReminderSeens = new HashSet<ReminderSeen>();
        }
        public DateTime? ReminderDate { get; set; }
        public string? ReminderType { get; set; }
        public string? EngineerName { get; set; }
        public string? ReminderDetails { get; set; }
        public int? ContractId{ get; set; }
        public int? JobId { get; set; }
        public int? VisitId { get; set; }
        public virtual Job Job { get; set; }
        public virtual Contract Contract { get; set; }
        public virtual ICollection<ReminderSeen> ReminderSeens { get; set; }
        public virtual Visit Visit { get; set; }
    }
}
