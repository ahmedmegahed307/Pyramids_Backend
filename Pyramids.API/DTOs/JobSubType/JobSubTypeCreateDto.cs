using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.JobSubType
{
    public class JobSubTypeCreateDto : EntityBaseDto
    {
        public string Name { get; set; }
        public int JobTypeId { get; set; }
        public int? CompanyId { get; set; }


    }
}
