using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.User
{
    public class UserUpdateDto :EntityBaseDto
    {
        public string? Initials { get; set; }
        public  string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? ProfilePhotoUrl { get; set; }

    }
}
