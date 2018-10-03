using Library.Domain.Enum;
using Library.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Domain.Repository.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            //Map to table
            builder.ToTable("FineStatus");

            // Primary key
            builder.HasKey(x => x.Id);

            //seeding data
            builder.HasData(
               new UserRole { Id = UserRoleEnum.Librarian, Role = "Librarian" },
               new UserRole { Id = UserRoleEnum.User, Role = "User" }
            );
        }
    }
}
