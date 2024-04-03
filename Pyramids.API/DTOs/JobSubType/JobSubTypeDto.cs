using Pyramids.API.DTOs.JobType;
using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.JobSubType
{
    public class JobSubTypeDto : EntityBaseDto
    {
        public string Name { get; set; }
        public int? JobTypeId { get; set; }
        public int? CompanyId { get; set; }
        public bool? IsActive { get; set; }

        public SubTypeJobTypeDto? JobType { get; set; }
    }
    public class SubTypeJobTypeDto : EntityBaseDto
    {
        public string Name { get; set; }
    }

}
