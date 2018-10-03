using Library.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Domain.Repository.Configuration
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Map to table
            builder.ToTable("User");

            // Primary key
            builder.HasKey(x => x.Id);

            // properties
            builder.Property(x => x.Id).UseSqlServerIdentityColumn();
            builder.Property(x => x.DisplayName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(50);

            // Relationships
            builder.HasOne(x => x.UserRole)
                   .WithMany(x => x.Users)
                   .HasForeignKey(x => x.RoleId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
