using System.ComponentModel.DataAnnotations;
using Pyramids.API.DTOs.JobSubType;
using Pyramids.Core.Models;
using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.JobType
{
    public class JobTypeCreateDto : EntityBaseDto
    {
        [Required]
        public string Name { get; set; }
        public int? CompanyId { get; set; }

    }
}
