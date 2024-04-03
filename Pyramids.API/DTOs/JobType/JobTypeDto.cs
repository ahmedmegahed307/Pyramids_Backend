using Pyramids.API.DTOs.JobSubType;
using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.JobType
{
    public class JobTypeDto : EntityBaseDto
    {
        public string Name { get; set; }
        public int? CompanyId { get; set; }
        public int? CreatedByUserId { get; set; }
        public List<JobSubTypeDto>? JobSubTypes { get; set; }

    }
}
