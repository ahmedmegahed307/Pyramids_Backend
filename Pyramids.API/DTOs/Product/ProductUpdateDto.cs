using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.Product
{
    public class ProductUpdateDto : EntityBaseDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public double StandardPrice { get; set; }
        public double JobPrice { get; set; }
        public bool SerialControlled { get; set; }
        public int CategoryId { get; set; }
        public string? Brand { get; set; }
        public int CompanyId { get; set; }
    }
}
