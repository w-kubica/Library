using Library.Domain.Models;

namespace Library.Infrastructure.DTO
{
    public class ReaderDb
    {
        public int Id { get; set; }
        public string? Pesel { get; set; }
        public List<BorrowedDb> Borrowed { get; set; } = new();

        public ReaderType ReaderType { get; set; }

        public ReaderDb(int id, string pesel, ReaderType readerType)
        {
            (Id, Pesel, ReaderType) = (id, pesel, readerType);
        }

        public ReaderDb(int id, ReaderType readerType)
        {
            (Id, ReaderType) = (id, readerType);
        }

        public ReaderDb()
        {

        }
    }
}
