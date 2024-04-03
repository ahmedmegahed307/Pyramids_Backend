using Pyramids.Shared.Entity;

namespace Pyramids.Core.Models
{
    public class JobAttachment : EntityBase
    {
        public int JobId { get; set; }
        public required string FileName { get; set; }
        public required string FileURL { get; set; }
        public required string FileType { get; set; }
    }
}
