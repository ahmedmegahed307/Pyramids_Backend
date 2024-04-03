using Pyramids.Core.Enums;

namespace Pyramids.API.DTOs.Reports.JobQuery
{
    public class JobQueryFilterDto
    {
        public JobDateTypeEnum? DateType { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? JobTypeId { get; set; }
        public int? JobSubTypeId { get; set; }
        public int? JobStatusId { get; set; }
        public int? JobPriorityId { get; set; }
        public int? ClientId { get; set; }
        public string? SiteId { get; set; }
        public int? CompanyId { get; set; }
    }
}
