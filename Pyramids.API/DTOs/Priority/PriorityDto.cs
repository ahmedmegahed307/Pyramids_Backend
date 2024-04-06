using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.Priority
{
    public class PriorityDto : EntityBaseDto
    {
         public required string Code { get; set; }
        public required string Name { get; set; }
    }
}
