using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.Client.Site
{
    public class SiteUpdateDto : EntityBaseDto
    {
        public int CompanyId { get; set; }

        public int ClientId { get; set; }
        public string Name { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }

        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public string? PostCode { get; set; }
    }
}
