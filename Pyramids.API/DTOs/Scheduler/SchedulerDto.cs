namespace Pyramids.API.DTOs.Scheduler
{
    public class SchedulerDto
    {
       
        public SchedulerEventDto Event { get; set; }
        public SchedulerJobDto Job { get; set; }
    }
    public class SchedulerEventDto
    {
        public int? Id { get; set; }
        public int CompanyId { get; set; }
        public string? EventType { get; set; }
        public string? Title { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Description { get; set; }
        public IEnumerable<EmployeeDto>? Employees{ get; set; }

    }
    public class EmployeeDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
    }
    public class SchedulerJobDto
    {
        public int Id { get; set; }
        public string? EventType { get; set; }
        public string? Title { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Description { get; set; }
        public int? ClientId { get; set; }
        public string ? ClientName { get; set; }
        public int? SiteId { get; set; }
        public string? SiteName { get; set; }
        public int? ContactId { get; set; }
        public string? ContactName { get; set; }
        public int JobTypeId { get; set; }
        public string? JobTypeName { get; set; }
        public int? JobSubTypeId { get; set; }
        public string? JobSubTypeName { get; set; }
        public int? EngineerId { get; set; }
        public string? EngineerName { get; set; }
        public int? JobStatusId { get; set; }
        public string? JobStatusName { get; set; } 

        public DateTime? ScheduleDateEnd { get; set; }
        public int? EstimatedDuration { get; set; }
    }
}
