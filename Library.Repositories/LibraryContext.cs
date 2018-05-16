using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositories
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public DbSet<LibraryItem> LibraryItems { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Visitor> Visitors { get; set; }

        private DbSet<Employee> Employees { get; set; }
    }
}