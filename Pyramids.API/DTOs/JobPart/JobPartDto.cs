using Pyramids.API.DTOs.Product;
using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.JobPart
{
    public class JobPartDto : EntityBaseDto
    {
        public int? JobId { get; set; }
        public int Quantity { get; set; }
        public int? ProductId { get; set; }

        public ProductDto Product { get; set; }
    }
}
