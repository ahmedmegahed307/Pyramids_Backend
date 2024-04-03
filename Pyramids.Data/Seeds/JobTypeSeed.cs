using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pyramids.Core.Models;

namespace Pyramids.Data.Seeds


{
    internal class JobTypeSeed : IEntityTypeConfiguration<JobType>
    {
        public JobTypeSeed()
        { }

        public void Configure(EntityTypeBuilder<JobType> builder)
        {
            builder.HasData(
                      new JobType { Id = 1, Name = "Commissioning", IsActive = true }
                );
        }
    }
}
