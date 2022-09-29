using Library.Infrastructure.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<BookDb>
    {
        public void Configure(EntityTypeBuilder<BookDb> builder)
        {
            builder.ToTable("Books");
            builder.HasKey(x => x.Id);
            builder.HasMany(b => b.Borrowed)
                .WithOne(a => a.Book);

          //  builder.Property(x => x.Title).IsRequired();

        }
    }
}
