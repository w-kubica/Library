using Library.Infrastructure.DTO;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }
        public DbSet<BookDb>? Books { get; set; }
        public DbSet<ReaderDb>? Readers { get; set; }

    }
}
