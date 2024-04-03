using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.Category
{
    public class CategoryCreateDto : EntityBaseDto
    {
        public required string Name { get; set; }
        public required string Code { get; set; }
        public string? Description { get; set; }
        public int CompanyId { get; set; }
    }
}
