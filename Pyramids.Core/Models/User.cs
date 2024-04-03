using System.Diagnostics.Contracts;
using Pyramids.Shared.Entity;

namespace Pyramids.Core.Models
{
    public class User : EntityBase, IActiveEntity, ICompanyEntity
    {
        public int CompanyId { get; set; }
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public required string LastName { get; set; }
        public string? Initials { get; set; }
        public string? PasswordHash { get; set; }
        public string? GeneratedPassword { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
        public int UserRoleId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? PasswordChangedDate { get; set; }
        public Guid? ResetPasswordKey { get; set; }
        public DateTime? ResetPasswordKeyValidToDate { get; set; }
        public string? CultureInfoCode { get; set; }
        public int? AddressId { get; set; }
        public bool? IsConfirmed { get; set; } = true;
        public Guid? ConfirmationKey { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public Guid? SessionToken { get; set; }
        public DateTime? SessionTokenDate { get; set; }
        public string? ProfileLogoFilename { get; set; }
        public string? LastDomainName { get; set; }
        public string? ProfilePhotoUrl { get; set; }
        public bool IsFirstLogin { get; set; } = true;

        public Company Company { get; set; }
        public UserRole UserRole { get; set; }
        public Address Address { get; set; }

        public ICollection<User> Users {get;set;}
    }
}
