using Pyramids.Shared.Entity;

namespace Pyramids.Core.Models
{
    public class Product : EntityBase, ICompanyEntity,IActiveEntity
    {
        public required string Code { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public double StandardPrice { get; set; }
        public double JobPrice { get; set; }
        public bool SerialControlled { get; set; }
        public int CategoryId { get; set; }
        public string? Brand { get; set; }
        public int CompanyId { get; set; }

    }
}
