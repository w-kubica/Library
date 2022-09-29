using Library.Infrastructure.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Data.Configurations
{
    public class ReaderConfiguration : IEntityTypeConfiguration<ReaderDb>
    {
        public void Configure(EntityTypeBuilder<ReaderDb> builder)
        {
            builder.ToTable("Readers");
            builder.HasKey(x => x.Id);
            builder.HasMany(b => b.Borrowed)
                .WithOne(r => r.Reader);
            builder.Property(x => x.Pesel).IsRequired();
            builder.Property(x => x.ReaderType).IsRequired();

        }
    }
}
