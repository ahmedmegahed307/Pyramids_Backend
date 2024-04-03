using Pyramids.Shared.Entity;

namespace Pyramids.Core.Models
{
    public class ReminderSeen :EntityBase
    {
        public int? ReminderId { get; set; }
        public int? SeenByUserId { get; set; }
 
        public virtual Reminder Reminder { get; set; }
        public virtual User SeenByUser { get; set; }
    }
}
