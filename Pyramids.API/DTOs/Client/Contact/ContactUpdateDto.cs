using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.Client.Contact
{
    public class ContactUpdateDto : EntityBaseDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? ContactType { get; set; }
        public int? ClientId { get; set; }

        public int? SiteId { get; set; }    
    }
}
