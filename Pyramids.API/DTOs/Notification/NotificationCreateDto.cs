using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.Notification
{
    public class NotificationCreateDto : EntityBaseDto
    {
        public required string Message { get; set; }

        public int? CreatedByUserId { get; set; }

        public int CompanyId { get; set; }
    }
}
