using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Pyramids.Core.Models;

namespace Pyramids.Data.Seeds
{
    public class JobStatusSeed : IEntityTypeConfiguration<JobStatus>
    {
        public JobStatusSeed()
        { }

        public void Configure(EntityTypeBuilder<JobStatus> builder)
        {
            builder.HasData(
                      new JobStatus { Id = 1, Name = "Assigned", Code = 'A' },
                      new JobStatus { Id = 2, Name = "Closed", Code = 'F' },
                      new JobStatus { Id = 3, Name = "Open", Code = 'O' },
                      new JobStatus { Id = 4, Name = "Pending", Code = 'P' },
                      new JobStatus { Id = 5, Name = "Resolved", Code = 'R' },
                      new JobStatus { Id = 6, Name = "Cancelled", Code = 'X' }
                );
        }
    }
}
