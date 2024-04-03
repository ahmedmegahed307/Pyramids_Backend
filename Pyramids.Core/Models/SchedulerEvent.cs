using Pyramids.Shared.Entity;

namespace Pyramids.Core.Models
{
    public class SchedulerEvent :EntityBase,ICompanyEntity,IActiveEntity
    {
        public int CompanyId { get; set; }
        public string EventType { get; set; }
        public string? Title {  get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public virtual int? ModifiedByUserId { get; set; }
        public virtual Company Company { get; set; }
        public string? EmployeesId { get; set; }

    }
}
