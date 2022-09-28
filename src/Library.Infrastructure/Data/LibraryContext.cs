using Library.Infrastructure.Data.Configurations;
using Library.Infrastructure.DTO;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Data
{
    public class LibraryContext : DbContext
    {
        public virtual DbSet<ReaderDb> Readers { get; set; } = null!;
        public virtual DbSet<BookDb> Books { get; set; } = null!;
        public virtual DbSet<BorrowedDb> Borrowed { get; set; } = null!;

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ReaderConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new BorrowedConfiguration());
        }

    }
}
