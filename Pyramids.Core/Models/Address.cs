using Pyramids.Shared.Entity;

namespace Pyramids.Core.Models
{
    public class Address : EntityBase
    {
        public required string AddressLine1 { get; set; }
        public required string AddressLine2 { get; set; }
     
        public string? City { get; set; }
        public string? PostCode { get; set; }
        public string? Country { get; set; }

        public User CreatedByUser { get; set; }
    }
}
