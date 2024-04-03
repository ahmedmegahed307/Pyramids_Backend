using System.ComponentModel.DataAnnotations;
using Pyramids.Shared.Entity;

namespace Pyramids.Core.Models
{
    public class UserRole : EntityBase
    {
        [MaxLength(100)]
        public required string Role { get; set; }
    }
}
