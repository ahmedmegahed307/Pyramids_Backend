using System.ComponentModel.DataAnnotations;
using Pyramids.Shared.Entity;

namespace Pyramids.Core.Models
{
    public class Contact : EntityBase,IActiveEntity
    {
        public string? Name { get; set; }
        public  string? Email { get; set; }
        public  string? Phone { get; set; }
        public string? ContactType { get; set; }
        public int? ClientId { get; set; }
        public int? SiteId { get; set; }
        public virtual Client Client { get; set; }
        public virtual Site Site { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }

    }
}
