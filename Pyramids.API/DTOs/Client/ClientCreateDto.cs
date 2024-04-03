using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.Client
{
    public class ClientCreateDto : EntityBaseDto
    {
         public int CompanyId { get; set; }
        public required string Code { get; set; }
        public required string Name { get; set; }
        public string? PrimaryContactName { get; set; }
        public string? PrimaryFinancialName { get; set; }
        public string? PrimaryContactEmail { get; set; }
        public string? PrimaryFinancialEmail { get; set; }
        public string? PrimaryContactPhone { get; set; }
        public string? Currency { get; set; }
        public string? VatRate { get; set; }
        public decimal VatNumber { get; set; }
        public string? VatValue { get; set; }
        public string? Fax { get; set; }
        public string? SiteType { get; set; }
    }
}
