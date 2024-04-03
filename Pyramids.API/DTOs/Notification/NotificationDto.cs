using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.Notification
{
    public class NotificationDto : EntityBaseDto
    {
        public required string Message { get; set; }

        public int? CreatedByUserId { get; set; }
        public string? UserFullName {  get; set; }
        public int CompanyId { get; set; }
        public  DateTimeOffset? CreatedAt { get; set; }
    }


}
