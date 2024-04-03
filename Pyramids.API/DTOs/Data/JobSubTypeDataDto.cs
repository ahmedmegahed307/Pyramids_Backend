using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.Data
{
    public class JobSubTypeDataDto : EntityBaseDto
    {
        public string Name { get; set; }
        public int JobTypeId { get; set; }
    }
}
