using Pyramids.Shared.Entity;

namespace Pyramids.Core.Models
{
    public class JobActionStatus : EntityBase
    {
        public required string StatusCode { get; set; }
        public required string Status { get; set; }
    }

}
