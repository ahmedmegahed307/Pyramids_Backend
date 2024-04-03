using Pyramids.Shared.Entity;

namespace Pyramids.Core.Models
{
    public class JobSurvey : EntityBase
    {
        public int? JobId { get; set; }
        public string? Other { get; set; }
        public int? ResponseTime { get; set; }
        public int? Punctuality { get; set; }
        public int? Quality { get; set; }
        public int? Courtesy { get; set; }
        public int? Overall { get; set; }
    }
}
