using Library.Infrastructure.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Data.Configurations
{
    public class BorrowedConfiguration : IEntityTypeConfiguration<BorrowedDb>
    {
        public void Configure(EntityTypeBuilder<BorrowedDb> builder)
        {
            builder.ToTable("Borrowed");
            builder.HasKey(x => x.Id);
            builder.HasOne(b => b.Book);
            builder.HasOne(r => r.Reader);
            builder.Property(x => x.BookId).IsRequired();
            builder.Property(x => x.ReaderId).IsRequired();
        }
    }
}
