namespace Pyramids.Core.Models
{
    public class JobSessionStatus
    {
        public int Id { get; set; }
        public required char StatusCode { get; set; }
        public required string Status { get; set; }
    }
}
