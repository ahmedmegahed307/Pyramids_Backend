using Pyramids.Core.Models;

namespace Pyramids.API.DTOs.Scheduler
{
    public class SchedulerEventUpdateDto
    {
        public string? Title { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Description { get; set; }
        public string? EmployeesId { get; set; }
        public DateTime? ModifiedDate { get; set; }= DateTime.Now;
        public virtual int? ModifiedByUserId { get; set; }
    }

    
}
