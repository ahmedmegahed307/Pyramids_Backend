using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.Data
{
    public class SiteDataDto : EntityBaseDto
    {
        public string? Name { get; set; }
        public int? ClientId { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
    }
}
