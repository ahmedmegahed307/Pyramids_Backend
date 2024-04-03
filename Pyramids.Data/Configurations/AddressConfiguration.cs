using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pyramids.Core.Models;

namespace Pyramids.Data.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.AddressLine1).IsRequired().HasMaxLength(100);
            builder.ToTable("Address");

            builder.HasOne(j => j.CreatedByUser)
                   .WithMany()
                   .HasForeignKey(j => j.CreatedByUserId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
