using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Pyramids.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramids.Data.Seeds
{
    public class JobActionStatusSeed : IEntityTypeConfiguration<JobActionStatus>
    {
        public JobActionStatusSeed()
        { }

        public void Configure(EntityTypeBuilder<JobActionStatus> builder)
        {
            builder.HasData(
                     new JobActionStatus { Id = 1, StatusCode = "CREATED", Status = "Created via admin", IsActive = true },
                     new JobActionStatus { Id = 2, StatusCode = "CANCELLED", Status = "Cancelled", IsActive = true },
                     new JobActionStatus { Id = 3, StatusCode = "ASSIGNED", Status = "Assigned", IsActive = true },
                     new JobActionStatus { Id = 4, StatusCode = "CLOSED_ADMIN", Status = "Closed via admin", IsActive = true },
                     new JobActionStatus { Id = 5, StatusCode = "RESOLVED_MOBILE", Status = "Resolved via mobile", IsActive = true },
                     new JobActionStatus { Id = 6, StatusCode = "TRAVEL_STARTED", Status = "Travel started on mobile", IsActive = true },
                     new JobActionStatus { Id = 7, StatusCode = "TRAVEL_CANCELLED", Status = "Travel cancelled on mobile", IsActive = true },
                     new JobActionStatus { Id = 8, StatusCode = "TRAVEL_FINISHED", Status = "Travel finished on mobile", IsActive = true },
                     new JobActionStatus { Id = 9, StatusCode = "WORK_STARTED", Status = "Work started on mobile", IsActive = true },
                     new JobActionStatus { Id = 10, StatusCode = "WORK_STOPPED", Status = "Work stopped on mobile", IsActive = true },
                     new JobActionStatus { Id = 11, StatusCode = "TRAVELBACK_STARTED", Status = "Travel started on mobile", IsActive = true },
                     new JobActionStatus { Id = 12, StatusCode = "TRAVELBACK_CANCELLED", Status = "Travel cancelled on mobile", IsActive = true },
                     new JobActionStatus { Id = 13, StatusCode = "TRAVELBACK_FINISHED", Status = "Travel finished on mobile", IsActive = true },
                     new JobActionStatus { Id = 15, StatusCode = "PHOTO_DELETED", Status = "Photo deleted", IsActive = true },
                     new JobActionStatus { Id = 16, StatusCode = "SIGN_CLIENT_ADDED", Status = "Client signature added", IsActive = true },
                     new JobActionStatus { Id = 17, StatusCode = "SIGN_ENG_ADDED", Status = "Engineer signature added", IsActive = true },
                     new JobActionStatus { Id = 18, StatusCode = "SIGN_CLIENT_DELETED", Status = "Client signature deleted", IsActive = true },
                     new JobActionStatus { Id = 19, StatusCode = "SIGN_ENG_DELETED", Status = "Engineer signature deleted", IsActive = true },
                     new JobActionStatus { Id = 20, StatusCode = "PART_ADDED", Status = "Part added", IsActive = true },
                     new JobActionStatus { Id = 21, StatusCode = "PART_DELETED", Status = "Part deleted", IsActive = true },
                     new JobActionStatus { Id = 22, StatusCode = "SAVED", Status = "Edited and saved", IsActive = true },
                     new JobActionStatus { Id = 23, StatusCode = "SEND_BACK_TO_ASSIGN", Status = "Send Back To Assigned", IsActive = true },
                     new JobActionStatus { Id = 24, StatusCode = "SEND_BACK_TO_OPEN", Status = "Send Back To Open", IsActive = true },
                     new JobActionStatus { Id = 25, StatusCode = "RESOLVED_ADMIN", Status = "Resolved via admin", IsActive = true },
                     new JobActionStatus { Id = 26, StatusCode = "EDIT_JOB", Status = "Job edited", IsActive = true },
                     new JobActionStatus { Id = 27, StatusCode = "ATTACHMENT_ADDED", Status = "Attachment added", IsActive = true },
                     new JobActionStatus { Id = 28, StatusCode = "ATTACHMENT_DELETED", Status = "Attachment deleted", IsActive = true },
                     new JobActionStatus { Id = 29, StatusCode = "SAVED_ON_MOBILE", Status = "Job saved on mobile", IsActive = true },
                     new JobActionStatus { Id = 30, StatusCode = "CREATED_MOBILE", Status = "Created via mobile", IsActive = true },
                     new JobActionStatus { Id = 31, StatusCode = "ASSIGNED_MOBILE", Status = "Assigned via mobile", IsActive = true },
                     new JobActionStatus { Id = 33, StatusCode = "ADD_PAYMENT", Status = "Added Payment", IsActive = true },
                     new JobActionStatus { Id = 34, StatusCode = "UPDATE_PAYMENT", Status = "Updated Payment", IsActive = true },
                     new JobActionStatus { Id = 35, StatusCode = "PENDING_REQUEST", Status = "Pending Requested by Client", IsActive = true },
                     new JobActionStatus { Id = 36, StatusCode = "WORK_REMOTE", Status = "Work remote started", IsActive = true },
                     new JobActionStatus { Id = 37, StatusCode = "STOP_REMOTE", Status = "Stop remote work", IsActive = true },
                     new JobActionStatus { Id = 38, StatusCode = "CLOSE_REMOTE", Status = "Close remote work", IsActive = true }
                     );
        }
    }
}
