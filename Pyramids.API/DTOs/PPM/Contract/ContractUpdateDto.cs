using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.PPM.Contract
{
    public class ContractUpdateDto 
    {
        public int CompanyId { get; set; }
        public int ClientId { get; set; }
        public string? ContractRef { get; set; }
        public string Description { get; set; }
        public int JobTypeId { get; set; }
        public int? JobSubTypeId { get; set; }
        public int? EstimatedDurationMinutes { get; set; }
        public int FrequencyType { get; set; }
        public int? FrequencyCount { get; set; } = 1;

        public double ContractCharge { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string BillingType { get; set; }
        public bool? IsActive { get; set; } = true;


    }
}
