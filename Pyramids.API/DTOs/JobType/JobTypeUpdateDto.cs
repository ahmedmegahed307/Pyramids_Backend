using System.ComponentModel.DataAnnotations;
using Pyramids.API.DTOs.JobSubType;
using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.JobType
{
    public class JobTypeUpdateDto : EntityBaseDto
    {
        public string? Name { get; set; }
    }
}
