using System.ComponentModel.DataAnnotations;
using Pyramids.Core.Models;

namespace Pyramids.API.DTOs.JobAction
{
    public class JobActionCreateDto
    {

        public string? Source { get; set; }
        public DateTime? ActionDate { get; set; } = DateTime.Now;
        public string? Comments { get; set; }
        [Required]
        public int JobId { get; set; }
        public int? ClientId { get; set; }
        public int? JobActionTypeId { get; set; }
        public int? JobSessionId { get; set; }
        [Required]
        public int CreatedByUserId { get; set; }
    }
}
