using Library.Domain.Models;
using Library.Infrastructure.DTO;

namespace Library.Infrastructure.Mappers
{
    public static class ReaderProfile
    {
        public static ReaderDb ToInfrastructure(this Reader reader) =>
            new(reader.Id, reader.Pesel, reader.ReaderType);

        public static ReaderDb ToInfrastructureUpdate(this Reader reader) =>
            new(reader.Id, reader.Pesel, reader.ReaderType);

        public static Reader ToDomain (this ReaderDb reader) =>
            new(reader.Id, reader.Pesel, reader.ReaderType);
    }
}
