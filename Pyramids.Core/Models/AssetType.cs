using Pyramids.Shared.Entity;

namespace Pyramids.Core.Models
{
    public class AssetType : EntityBase, ICompanyEntity,IActiveEntity
    {
        public required string Code { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int CompanyId { get; set; }
    }
}
