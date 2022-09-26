using Library.Domain.Models;
using Library.Infrastructure.DTO;

namespace Library.Application.Mappers
{
    public static class ReaderProfile
    {
        public static ReaderDto ToApplication(this Reader reader) =>
            new(reader.Id, reader.Pesel, reader.ReaderType);

        public static Reader ToDomain(this ReaderDto reader) =>
            new(reader.Id, reader.Pesel, reader.ReaderType);
    }
}
