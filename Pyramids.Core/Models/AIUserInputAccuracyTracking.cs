using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramids.Core.Models
{
    public class AIUserInputAccuracyTracking
    {
        public int Id { get; set; }
        public int? ProcessedByUserId { get; set; }
        public int? CompanyId { get; set; }
        public string? UserInput { get; set; }
        public string? UserInputIntent { get; set; }
        public int? UserInputIntentConfidenceScore { get; set; }
        public bool? Accuracy { get; set; }
        public DateTime? Timestamp { get; set; }=DateTime.Now;

    }
}
