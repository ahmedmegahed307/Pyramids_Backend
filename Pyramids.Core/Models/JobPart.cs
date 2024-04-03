using Pyramids.Shared.Entity;

namespace Pyramids.Core.Models
{
    public class JobPart : EntityBase,IActiveEntity
    {
        public int? JobId { get; set; }
        public int? ProductId { get; set; }
        public int Quantity { get; set; }
        public virtual Job Job { get; set; }
        public virtual Product Product { get; set; }
    }
}
