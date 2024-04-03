using Pyramids.Shared.Entity;

namespace Pyramids.Core.Models
{
    public class WorkDocket : EntityBase
    {
        public required string WorkdocketCode { get; set; }
        public int? JobId { get; set; }

    }
}
