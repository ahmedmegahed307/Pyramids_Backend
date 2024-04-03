using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.Address
{
    public class AddressDto : EntityBaseDto
    {
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? PostCode { get; set; }
    }
}
