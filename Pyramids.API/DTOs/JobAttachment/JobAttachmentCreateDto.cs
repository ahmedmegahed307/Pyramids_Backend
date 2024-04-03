using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.JobAttachment
{
    public class JobAttachmentCreateDto : EntityBaseDto
    {
        public int JobId { get; set; }

        public IFormFile? FileToUpload { get; set; }
        public int? CreatedByUserId { get; set; }

    }
}
