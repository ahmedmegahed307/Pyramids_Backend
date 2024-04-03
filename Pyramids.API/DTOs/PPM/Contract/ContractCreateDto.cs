using System.ComponentModel.DataAnnotations;
using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.PPM.Contract
{
    public class ContractCreateDto : EntityBaseDto
    {
      
        [Required]
        public int ClientId { get; set; }
        public string? ContractRef { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public int JobTypeId { get; set; }
        public int? JobSubTypeId { get; set; }
        public int? EstimatedDurationMinutes { get; set; }
 
        public int? FrequencyType { get; set; } = 30;
        public int? FrequencyCount { get; set; } = 1;
        public double? ContractCharge { get; set; }
        public DateTime? StartDate { get; set; }=DateTime.Now.Date;
        public DateTime? ModifiedDate { get; set; }=DateTime.Now.Date;
        public DateTime? ExpiryDate { get; set; }=DateTime.Now.AddYears(1).Date;
        public string? BillingType { get; set; }
        public int? CreatedByUserId { get; set; }
       
    }
}
