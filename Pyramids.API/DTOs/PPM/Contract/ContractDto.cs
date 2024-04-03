using Pyramids.API.DTOs.PPM.Reminder;
using Pyramids.API.DTOs.PPM.Visit;
using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.PPM.Contract
{
    public class ContractDto : EntityBaseDto
    {

        public string? ContractRef { get; set; }
        public int? CompanyId { get; set; }
        public int? JobTypeId { get; set; }
        public string? JobTypeName { get; set; }
        public int? JobSubTypeId { get; set; }
        public string? JobSubTypeName { get; set; }
        public string? Description { get; set; }
        public int? ClientId { get; set; }
        public string? ClientName { get; set; }
        public string? Status { get; set; }
        public string? BillingType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? NextVisitDate { get; set; }
        public int? FrequencyType { get; set; }
        public int? EstimatedDurationMinutes { get; set; }
        public double? ContractCharge { get; set; }
        public List<VisitDto> Visits { get; set; }
        public List<ReminderDto> Reminders { get; set; }
      
    }

    

   

}
