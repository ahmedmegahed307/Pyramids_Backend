using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.Notification
{
    public class NotificationUpdateDto : EntityBaseDto
    {
        public required string Message { get; set; }
        public int CompanyId { get; set; }
    }
}
