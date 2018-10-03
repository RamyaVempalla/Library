using Library.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Domain.Repository.Configuration
{
    class FineConfiguration : IEntityTypeConfiguration<Fine>
    {
        public void Configure(EntityTypeBuilder<Fine> builder)
        {
            // Map to table
            builder.ToTable("Allocation");

            // Primary key
            builder.HasKey(x => x.Id);

            // properties
            builder.Property(x => x.Id).UseSqlServerIdentityColumn();
            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(5);
            builder.Property(x => x.ModifiedBy).HasMaxLength(5);
            builder.Property(x => x.CreatedDate).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ModifiedDate).HasMaxLength(50);

            // Relationships
            builder.HasOne(x => x.Allocation)
                   .WithOne(x => x.Fine)
                   .HasForeignKey<Fine>(x => x.BorrowId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.FineStatus)
                  .WithMany(x => x.Fines)
                  .HasForeignKey(x => x.StatusId)
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
