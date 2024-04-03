using Pyramids.Shared.Entity;

namespace Pyramids.Core.Models
{
    public class Site : EntityBase,IActiveEntity,ICompanyEntity
    {
        public int? ClientId { get; set; }
        public int CompanyId {  get; set; }
        public string Name { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public string? PostCode { get; set; }
        public virtual Client Client { get; set; }
        public virtual Company Company { get; set; }
    }
}
