using Library.Domain.Enum;
using Library.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Domain.Repository.Configuration
{
    class BookStatusConfiguration : IEntityTypeConfiguration<BookStatus>
    {
        public void Configure(EntityTypeBuilder<BookStatus> builder)
        {
            //Map to table
            builder.ToTable("BookStatus");

            // Primary key
            builder.HasKey(x => x.Id);

            //seeding data
            builder.HasData(
               new BookStatus { Id = BookStatusEnum.Issued, Status = "Issued" },
               new BookStatus { Id = BookStatusEnum.pending, Status = "pending" },
               new BookStatus { Id = BookStatusEnum.Deleted, Status = "Deleted" }
            );
        }
    }
}
