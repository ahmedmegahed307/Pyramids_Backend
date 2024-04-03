using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.Data
{
    public class UserDataDto : EntityBaseDto
    {
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Initials { get; set; }
    }
}
