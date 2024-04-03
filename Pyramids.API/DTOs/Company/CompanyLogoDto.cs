namespace Pyramids.API.DTOs.Company
{
    public class CompanyLogoDto
    {
        public int? CompanyId { get; set; }
        public IFormFile logo { get; set; }
    }
}
