using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.AssetManufacturer
{
    public class AssetManufacturerUpdateDto : EntityBaseDto
    {
        public required string Code { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public int CompanyId { get; set; }
    }
}
