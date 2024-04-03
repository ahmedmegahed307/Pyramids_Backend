namespace Pyramids.Core.Models.AI
{
    public class TextProcessingRequest
    {
        public required string Text { get; set; }
        public required int UserId { get; set; }
        public required int CompanyId { get; set; }
    }
}
