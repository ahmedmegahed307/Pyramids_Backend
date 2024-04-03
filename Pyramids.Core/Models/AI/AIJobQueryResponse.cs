namespace Pyramids.Core.Models.AI
{
    public class AIJobQueryResponse
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string? JobTypeName { get; set; }
        public string? JobSubTypeName { get; set; }
        public string? JobStatusName { get; set; }
        public string? JobPriorityName { get; set; }
        public string? ClientName { get; set; }
        public string? SiteName { get; set; }
        public int? CompanyId { get; set; }

    }
}
