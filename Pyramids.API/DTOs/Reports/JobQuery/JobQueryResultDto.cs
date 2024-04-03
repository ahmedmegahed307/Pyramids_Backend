using Pyramids.API.DTOs.JobPart;
using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.Reports.JobQuery
{
    public class JobQueryResultDto
    {

        public int? JobId { get; set; }
        public DateTime? JobDate { get; set; }
        public DateTime? ScheduleDateEnd { get; set; }
        public DateTime? AssignedDate { get; set; }
        public int? EstimatedDuration { get; set; }
        public string? Description { get; set; }
        public int? ClientId { get; set; }
        public string? ClientName { get; set; }

        public int? JobTypeId { get; set; }
        public string? JobTypeName { get; set; }
        public int? JobSubTypeId { get; set; }
        public string? JobSubTypeName { get; set; }
        public int? EngineerId { get; set; }
        public string? EngineerName { get; set; }
        public int? PriorityId { get; set; }
        public string? PriorityName { get; set; }
        public int? StatusId { get; set; }
        public string? StatusName { get; set; }
        public JobQuerySiteDto? Site { get; set; }

    }



    public class JobQuerySiteDto : EntityBaseDto
    {
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
    }

}

