using Library.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Library.Infrastructure.DTO
{
    public class ReaderDb
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Pesel { get; set; }

        public List<BorrowedDb> Borrowed { get; set; } = new List<BorrowedDb>();

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
