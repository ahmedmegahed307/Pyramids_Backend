using System.ComponentModel.DataAnnotations;
using Pyramids.Shared.Entity;

namespace Pyramids.Core.Models
{
    public class JobSubType : EntityBase, ICompanyEntity, IActiveEntity
    {
        public required string Name {  get; set; }
        public  int? JobTypeId { get; set; }
        [Required]
        public  int CompanyId { get; set; }
        public JobType? JobType { get; set; }
    }

  

}
