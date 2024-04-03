using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.JobPart
{
    public class JobPartCreateDto : EntityBaseDto
    {
        public int JobId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
