using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.Asset
{
    public class AssetUpdateDto : EntityBaseDto
    {
        public required string SerialNo { get; set; }
        public int AssetTypeId { get; set; }
        public int CompanyId { get; set; }
        public int? ClientId { get; set; }
        public int? SiteId { get; set; }
        public int AssetModelId { get; set; }
        public int AssetManufacturerId { get; set; }
        public string? TagNo { get; set; }
        public int Quantity { get; set; }
        public string? Description { get; set; }
    }
}
