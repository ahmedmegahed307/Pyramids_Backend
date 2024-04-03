using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.PPM.Visit
{
    public class VisitDto : EntityBaseDto
    {
        public string? ClientName { get; set; }
        public string? ContractRef { get; set; }
        public int? JobId { get; set; }
        public string? EngineerName { get; set; }

        public string? JobStatus { get; set; }
        public string? Description { get; set; }    
        public int? CompanyId { get; set; }
        public bool? IsGenerated { get; set; }
        public DateTime? VisitDate { get; set; }
        public DateTime? GeneratedDate { get; set; }
        public int? GeneratedByUserId { get; set; }
        public bool? InvoiceRow { get; set; }
    }
}
