using Pyramids.Shared.Entity;

namespace Pyramids.Core.Models
{
    public class Client : EntityBase, IActiveEntity,ICompanyEntity
    {
        public required string Name { get; set; }
        public string? PrimaryContactName { get; set; }
        public string? PrimaryFinancialName { get; set; }
        public string? PrimaryContactEmail { get; set; }
        public string? PrimaryFinancialEmail { get; set; }
        public string? PrimaryContactPhone { get; set; }
        public string? Currency { get; set; }
        public string? VatRate { get; set; }
        public string? VatNumber { get; set; }
        public string? VatValue { get; set; }
        public string? Fax { get; set; }
        public string? LogoUrl { get; set; }
        public string? Code { get; set; }
        public int CompanyId { get; set; }
        public string? SiteType { get; set; }
        public virtual ICollection<Site> Sites { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
        public virtual ICollection<Asset> Assets { get; set; }
    }
}
