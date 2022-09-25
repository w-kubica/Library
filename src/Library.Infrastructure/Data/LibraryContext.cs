using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<BookDb>? Books { get; set; }

    }
}
