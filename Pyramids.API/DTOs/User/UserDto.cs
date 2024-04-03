using Pyramids.API.DTOs.Client.Site;
using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.User
{
    public class UserDto : EntityBaseDto
    {
        public string? Initials { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public string? ContactName { get; set; }
        public bool? IsActive { get; set; } = true;
        public string? Phone { get; set; }
        public int UserRoleId { get; set; }
        public int? CompanyId { get; set; }
        public string? ProfilePhotoUrl { get; set; }

        public string? Email { get; set; }
    }
}
