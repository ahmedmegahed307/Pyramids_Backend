using Pyramids.Shared.Entity;

namespace Pyramids.Core.Models
{
    public class Asset : EntityBase,ICompanyEntity,IActiveEntity
    {
        public required string SerialNo { get; set; }
        public int CompanyId { get; set; }
        public int? ClientId { get; set; }
        public int AssetModelId { get; set; }
        public int AssetManufacturerId { get; set; }
        public int AssetTypeId { get; set; }
        public int? SiteId { get; set; }
        public string? TagNo { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
        public AssetModel? AssetModel { get; set; }
        public AssetManufacturer? AssetManufacturer { get; set; }
        public AssetType? AssetType { get; set; }
        public Client Client { get; set; }
    }

}
