using Library.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Domain.Repository.Configuration
{
    class AllocationConfiguration : IEntityTypeConfiguration<Allocation>
    {
        public void Configure(EntityTypeBuilder<Allocation> builder)
        {
            // Map to table
            builder.ToTable("Allocation");

            // Primary key
            builder.HasKey(x => x.Id);

            // properties
            builder.Property(x => x.Id).UseSqlServerIdentityColumn();
            builder.Property(x => x.BorrowDate).HasMaxLength(50);
            builder.Property(x => x.ReturnDate).HasMaxLength(50);
            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(5);
            builder.Property(x => x.ModifiedBy).HasMaxLength(5);
            builder.Property(x => x.CreatedDate).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ModifiedDate).HasMaxLength(50);

            // Relationships
            builder.HasOne(x => x.User)
                   .WithMany(x => x.Allocations)
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Book)
                  .WithMany(x => x.Allocations)
                  .HasForeignKey(x => x.BookId)
                  .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.BookStatus)
                  .WithMany(x => x.Allocations)
                  .HasForeignKey(x => x.StatusId)
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
