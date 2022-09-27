using Library.Application.DTO;
using Library.Domain.Models;

namespace Library.Application.Mappers
{
    public static class ReaderProfile
    {
        public static ReaderDto ToApplication(this Reader reader) =>
            new(reader.Id, reader.Pesel, reader.ReaderType);

        public static Reader ToDomain(this ReaderDto reader) =>
            new(reader.Id, reader.Pesel, reader.ReaderType);

        public static Reader ToDomain(this UpdateReaderDto reader) =>
            new(reader.Id, reader.ReaderType);

    }
}
