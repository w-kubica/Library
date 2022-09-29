using Library.Domain.Models;
using Library.Infrastructure.DTO;

namespace Library.Infrastructure.Mappers
{
    public static class ReaderProfile
    {
        public static ReaderDb ToInfrastructure(this Reader reader) =>
            new(reader.Id, reader.Pesel, reader.ReaderType);

        public static Reader ToDomain (this ReaderDb reader)
        {
            if (reader.Pesel != null) 
                return new(reader.Id, reader.Pesel, reader.ReaderType);
            throw new Exception($"There is no reader with id: {reader.Id}");
        }
    }
}
