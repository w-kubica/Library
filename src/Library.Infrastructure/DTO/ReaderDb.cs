using Library.Domain.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Infrastructure.DTO
{
    [Table("Readers")]
    public class ReaderDb
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Pesel { get; set; }
      
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
