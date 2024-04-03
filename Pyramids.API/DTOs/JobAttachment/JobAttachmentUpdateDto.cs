using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.JobAttachment
{
    public class JobAttachmentUpdateDto : EntityBaseDto
    {
        public int JobId { get; set; }
        public required string FileName { get; set; }
        public required string FileURL { get; set; }
        public required string FileType { get; set; }
    }
}
