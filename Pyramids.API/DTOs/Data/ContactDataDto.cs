using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.Data
{
  
    public class ContactDataDto : EntityBaseDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int? ClientId { get; set; }
        public int? SiteId { get; set; }
    }
}
