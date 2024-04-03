using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pyramids.Core.Models;

namespace Pyramids.Data.Seeds



{
    public class UserRoleSeed : IEntityTypeConfiguration<UserRole>
    {
        public UserRoleSeed()
        { }

        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasData(
                      new UserRole { Id = 1, Role = "Admin" },
                      new UserRole { Id = 2, Role = "Engineer" },
                      new UserRole { Id = 3, Role = "Client" }
                );
        }
    }
}
