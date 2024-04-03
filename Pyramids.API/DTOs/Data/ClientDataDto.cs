using Pyramids.API.DTOs.Client.Contact;
using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.Data
{
    public class ClientDataDto : EntityBaseDto
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? PrimaryContactName { get; set; }
        public string? PrimaryContactEmail { get; set; }
        public string? PrimaryContactPhone { get; set; }
    }
}
