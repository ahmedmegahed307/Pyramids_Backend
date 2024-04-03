namespace Pyramids.Core.Models
{
    public class JobStatus
    {
        public int Id { get; set; }
        public required char Code { get; set; }
        public required string Name { get; set; }
    }
}
