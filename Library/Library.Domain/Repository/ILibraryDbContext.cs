using Library.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Library.Domain.Repository
{
    public interface ILibraryDbContext
    {
        DbSet<Allocation> Allocation { get; set; }
        DbSet<Book> Book { get; set; }
        DbSet<BookStatus> BookStatus { get; set; }
        DbSet<Fine> Fine { get; set; }
        DbSet<FineStatus> FineStatus { get; set; }
        DbSet<User> User { get; set; }
        DbSet<UserRole> UserRole { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
