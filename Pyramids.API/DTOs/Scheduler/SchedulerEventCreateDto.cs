using Pyramids.Core.Models;

namespace Pyramids.API.DTOs.Scheduler
{
    public class SchedulerEventCreateDto
    {
        public int CompanyId { get; set; }
        public string? EventType { get; set; }
        public string? Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Description { get; set; }
        public string? EmployeesId { get; set; }
        public int? CreatedByUserId { get; set; }
    }

    
}
