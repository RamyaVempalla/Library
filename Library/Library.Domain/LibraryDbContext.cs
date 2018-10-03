using Library.Domain.Model;
using Library.Domain.Repository;
using Library.Domain.Repository.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Domain
{
    public class LibraryDbContext : DbContext, ILibraryDbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

        public DbSet<Allocation> Allocation { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<BookStatus> BookStatus { get; set; }
        public DbSet<Fine> Fine { get; set; }
        public DbSet<FineStatus> FineStatus { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AllocationConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new BookStatusConfiguration());
            modelBuilder.ApplyConfiguration(new FineConfiguration());
            modelBuilder.ApplyConfiguration(new FineStatusConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            try
            {
                TrackAuditablesChanges();
                return await base.SaveChangesAsync(cancellationToken);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void TrackAuditablesChanges()
        {
            var changedEntities = ChangeTracker.Entries().Where(entity => entity.Entity is Auditable);

            if (changedEntities.Any())
            {
                var date = DateTime.Now;

                changedEntities.AsParallel().ForAll(entity =>
                {
                    var auditable = entity.Entity as Auditable;
                    switch (entity.State)
                    {
                        case EntityState.Added:
                            auditable.CreatedDate = date;
                            break;
                        case EntityState.Modified:
                            auditable.ModifiedDate = date;
                            break;
                    }
                });
            }
        }
    }
}
