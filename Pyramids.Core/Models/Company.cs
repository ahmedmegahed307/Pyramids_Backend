using Pyramids.Shared.Entity;

namespace Pyramids.Core.Models
{
    public class Company : EntityBase,IActiveEntity
    {
        public required string Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Fax { get; set; }

        public int? AddressId { get; set; }
        public bool? IsSendPostWorkSurvey { get; set; } = false;
        public bool? IsSignatureRequired { get; set; } = false;
        public bool? IsResolutionRequired { get; set; } = false;
        public string? ClientPortalUrl { get; set; }
        public string? LogoFileName { get; set; }
        public string? LogoUrl { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? PrimaryIndustry { get; set; }
        public string? TermsAndConditions { get; set; }

        public string? VatNumber { get; set; }
        public string? PaymentTerm { get; set; }
        public string? Currency { get; set; }
        public bool? Taxable { get; set; } = false;
        public string? NormalWorkingHours { get; set; }
        public decimal? NormalHourlyRate { get; set; }
        public string? OverTimeWorkingHours { get; set; }
        public decimal? OvertimeHourlyRate { get; set; }
        public virtual Address Address { get; set; }
    }
}
