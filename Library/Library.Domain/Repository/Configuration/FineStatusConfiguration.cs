using Library.Domain.Enum;
using Library.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Domain.Repository.Configuration
{
    public class FineStatusConfiguration : IEntityTypeConfiguration<FineStatus>
    {
        public void Configure(EntityTypeBuilder<FineStatus> builder)
        {
            //Map to table
            builder.ToTable("FineStatus");

            // Primary key
            builder.HasKey(x => x.Id);

            //seeding data
            builder.HasData(
               new FineStatus { Id = FineStatusEnum.paid, Status = "paid" },
               new FineStatus { Id = FineStatusEnum.pending, Status = "pending" }
            );
        }
    }
}
