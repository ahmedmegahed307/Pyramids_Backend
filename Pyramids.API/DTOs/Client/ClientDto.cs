using Pyramids.API.DTOs.Asset;
using Pyramids.API.DTOs.Client.Contact;
using Pyramids.API.DTOs.Client.Site;
using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.Client
{
    public class ClientDto : EntityBaseDto
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? PrimaryContactName { get; set; }
        public string? PrimaryFinancialName { get; set; }
        public string? PrimaryContactEmail { get; set; }
        public string? PrimaryFinancialEmail { get; set; }
        public string? PrimaryContactPhone { get; set; }
        public string? Currency { get; set; }
        public string? SiteType { get; set; }
        public string? VatRate { get; set; }
        public string? VatNumber { get; set; }
        public string? VatValue { get; set; }
        public string? Fax { get; set; }
        public string? LogoUrl { get; set; }
        public int CompanyId { get; set; }
        public List<SiteDto> Sites { get; set; }
        public List<ContactDto> Contacts { get; set; }
        public List<AssetDto> Assets { get; set; }
    }
}
