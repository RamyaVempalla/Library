using Library.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Domain.Repository.Configuration
{
    class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            // Map to table
            builder.ToTable("Allocation");

            // Primary key
            builder.HasKey(x => x.Id);

            // properties
            builder.Property(x => x.Id).UseSqlServerIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Author).IsRequired().HasMaxLength(50);
            builder.Property(x => x.PublishYear).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(5);
            builder.Property(x => x.ModifiedBy).HasMaxLength(5);
            builder.Property(x => x.CreatedDate).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ModifiedDate).HasMaxLength(50);
        }
    }
}
