using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.JobAttachment
{
    public class JobAttachmentDto :EntityBaseDto
    {
        public int JobId { get; set; }
        public  string? FileName { get; set; }
        public  string? FileURL { get; set; }
        public  string? FileType { get; set; }
    }
}
