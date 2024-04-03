using Pyramids.Shared.Entity;

namespace Pyramids.API.DTOs.JobAction
{
    public class JobActionDto : EntityBaseDto
    {

        public string? Source { get; set; }
        public DateTime? ActionDate { get; set; }
        public string? Comments { get; set; }
        public JobActionUserDto? CreatedByUser { get; set; }
        public JobActionJobActionTypeDto? JobActionType { get; set; }


    }
    public class JobActionUserDto : EntityBaseDto
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class JobActionJobActionTypeDto : EntityBaseDto
    {

        public string Name { get; set; }
        public string Code { get; set; }
    }
}
