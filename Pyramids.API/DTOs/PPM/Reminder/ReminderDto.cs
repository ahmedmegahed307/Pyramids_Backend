using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.PPM.Reminder
{
    public class ReminderDto:EntityBaseDto
    {
        public string? ClientName { get; set; }
        public string? ContractRef { get; set; } 
        public int? JobId { get; set; }
        public DateTime? ReminderDate { get; set; }
        public string? ReminderDetails { get; set; }
        public string? EngineerName { get; set; }

    }
}
