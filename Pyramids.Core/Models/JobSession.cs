using Pyramids.Shared.Entity;

namespace Pyramids.Core.Models
{
    public class JobSession : EntityBase
    {
        public int? ClientId { get; set; }
        public int? SiteId { get; set; }
        public int? JobId { get; set; }
        public int? SessionStatusId { get; set; }
        public int? EngineerAssignedId { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public DateTime? TravelStart { get; set; }
        public DateTime? TravelEnd { get; set; }
        public DateTime? WorkStart { get; set; }
        public DateTime? WorkEnd { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime? ScheduleDateOrigin { get; set; }
        public DateTime? TravelStartOrigin { get; set; }
        public DateTime? TravelEndOrigin { get; set; }
        public DateTime? WorkStartOrigin { get; set; }
        public DateTime? WorkEndOrigin { get; set; }
        public bool? IsTraveling { get; set; }
        public bool? IsWorking { get; set; }
        public Guid? LocalId { get; set; }
        public DateTime? TravelBackStart { get; set; }
        public DateTime? TravelBackEnd { get; set; }

        public virtual User CreatedByUser { get; set; }
        public virtual User EngineerAssigned { get; set; }
        public virtual Job Job { get; set; }
    }
}
