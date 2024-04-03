using Pyramids.Shared.Entity;

namespace Pyramids.Core.Models
{
    public class JobFile : EntityBase
    {
        public int? CompanyId { get; set; }
        public int? JobId { get; set; }
        public string? Name { get; set; }
        public string? NameOnDisk { get; set; }
        public int? SizeInBytes { get; set; }
        public string? Type { get; set; }
        public DateTime UploadedDate { get; set; }
        public int? JobSessionId { get; set; }
        public int? LocalId { get; set; }
    }
}
