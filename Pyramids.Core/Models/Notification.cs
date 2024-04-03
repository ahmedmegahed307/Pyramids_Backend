using System.ComponentModel.DataAnnotations;
using Pyramids.Shared.Entity;

namespace Pyramids.Core.Models
{
    public class Notification : EntityBase,ICompanyEntity,IActiveEntity
    {
        public required string Message { get; set; }

        public User CreatedByUser {  get; set; }

        public int CompanyId {  get; set; }
        public Company Company { get; set; }

    }

}
