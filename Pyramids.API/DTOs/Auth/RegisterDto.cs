
namespace Pyramids.API.DTOs.Auth
{
    public class RegisterEngineerDto
    {
        public required string FirstName { get; set; }
        public string MiddleName { get; set; }
        public required string LastName { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        public string OutsourceCompanyName { get; set; }
        public int WarrantyPeriod { get; set; } = 3;
        public bool IsActive { get; set; } = true;
    }

    public class RegisterAdminDto
    {
        public required string FirstName { get; set; }
        public string MiddleName { get; set; }
        public required string LastName { get; set; }
        public required string Password { get; set; }
        public required string Email { get; set; }
        public required string CompanyName { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
