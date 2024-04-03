using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.User
{
    public class UserCreateDto :EntityBaseDto
    { 
        public required string FirstName {  get; set; }
        public required string LastName {  get; set; }
        public  string? ContactName {  get; set; }
        public Guid PasswordHash { get; set; } = Guid.NewGuid();
        public required string Email { get; set; }
        public  string? Phone { get; set; }
        public required int CompanyId { get; set; }
        public required int UserRoleId { get; set; }
    }
}
