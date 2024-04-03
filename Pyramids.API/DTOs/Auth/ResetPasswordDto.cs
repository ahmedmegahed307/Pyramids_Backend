namespace Pyramids.API.DTOs.Auth
{
    public class ResetPasswordDto
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string ResetPasswordCode { get; set; }
    }
}
