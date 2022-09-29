using Library.Infrastructure.Data.Configurations;
using Library.Infrastructure.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Library.Infrastructure.Data
{
    public class LibraryContext : DbContext
    {
        private readonly IConfiguration? _configuration;
        public virtual DbSet<ReaderDb> Readers { get; set; } = null!;
        public virtual DbSet<BookDb> Books { get; set; } = null!;
        public virtual DbSet<BorrowedDb> Borrowed { get; set; } = null!;

        public LibraryContext(DbContextOptions<LibraryContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("LibraryCS"));
                optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ReaderConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new BorrowedConfiguration());
        }

    }
}
