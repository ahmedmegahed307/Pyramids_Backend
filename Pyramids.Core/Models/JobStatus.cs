namespace Pyramids.Core.Models
{
    public class JobStatus
    {
        public int Id { get; set; }
        public required char StatusCode { get; set; }
        public required string Status { get; set; }
    }
}
