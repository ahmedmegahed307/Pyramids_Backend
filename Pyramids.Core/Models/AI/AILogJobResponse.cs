namespace Pyramids.Core.Models.AI
{
    public class AILogJobResponse
    {
        public int? ClientId { get; set; }
        public string? ClientName { get; set; }
        public int? SiteId { get; set; }
        public string? SiteName { get; set; }
        public int? JobTypeId { get; set; }
        public string? JobTypeName { get; set; }
        public int? JobSubTypeId { get; set; }
        public string? JobSubTypeName { get; set; }
        public int? EngineerId { get; set; }
        public string? EngineerName { get; set; }
        public DateTime? JobDate { get; set; } = DateTime.Now;
        public int? EstimatedDuration { get; set; } = 120;
        public string? IssueDescription { get; set; }
        public string? Description { get; set; } 


    }
}
