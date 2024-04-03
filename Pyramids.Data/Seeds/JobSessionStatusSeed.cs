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
    public class JobSessionStatusSeed : IEntityTypeConfiguration<JobSessionStatus>
    {
        public JobSessionStatusSeed()
        { }

        public void Configure(EntityTypeBuilder<JobSessionStatus> builder)
        {
            builder.HasData(
                      new JobSessionStatus { Id = 1, Status = "NotStarted", StatusCode = 'N' },
                      new JobSessionStatus { Id = 2, Status = "Traveling", StatusCode = 'T' },
                      new JobSessionStatus { Id = 3, Status = "Working", StatusCode = 'W' },
                      new JobSessionStatus { Id = 4, Status = "StopWorking", StatusCode = 'S' },
                      new JobSessionStatus { Id = 5, Status = "Closed", StatusCode = 'C' }
                );
        }
    }
}
