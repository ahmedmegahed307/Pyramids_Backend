using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pyramids.Core.Models;

namespace Pyramids.Data.Seeds


{
    public class CompanySeed : IEntityTypeConfiguration<Company>
    {
        public CompanySeed()
        { }

        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData(
                    new Company { Id = 1, Name = "Pyramids", Email = "support@pyramids.com", IsActive = true }
                );
        }
    }
}
