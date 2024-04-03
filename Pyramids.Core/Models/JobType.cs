using Pyramids.Shared.Entity;

namespace Pyramids.Core.Models
{
    public class JobType : EntityBase ,IActiveEntity, ICompanyEntity
    {
        public required string Name { get; set; }
        public int CompanyId {  get; set; }
        public ICollection<JobSubType>? JobSubTypes { get; set; }
    }
}
