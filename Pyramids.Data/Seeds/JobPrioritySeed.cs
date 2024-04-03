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
    public class JobPrioritySeed : IEntityTypeConfiguration<Priority>
    {
        public JobPrioritySeed()
        { }

        public void Configure(EntityTypeBuilder<Priority> builder)
        {
            builder.HasData(
                      new Priority { Id = 1, Code = "h", Name = "high" },
                      new Priority { Id = 2, Code = "m", Name = "medium" },
                      new Priority { Id = 3, Code = "l", Name = "low" }
                );
        }
    }
}
