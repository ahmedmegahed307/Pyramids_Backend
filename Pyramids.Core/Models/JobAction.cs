using Pyramids.Shared.Entity;

namespace Pyramids.Core.Models
{
    public class JobAction : EntityBase
    {
     


        public string? Source { get; set; }
        public DateTime? ActionDate { get; set; }
        public string? Comments { get; set; }
        public int? JobId { get; set; }
        public int? ClientId { get; set; }
        public int? JobActionTypeId { get; set; }
        public int? JobSessionId { get; set; }

        public virtual Job Job { get; set; }
        public virtual User CreatedByUser { get; set; }
        public virtual Client Client { get; set; }
        public virtual JobActionType JobActionType { get; set; }
        public virtual JobSession JobSession { get; set; }


    }

}
