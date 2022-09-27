using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Infrastructure.DTO
{
    [Table("Books")]
    public class BookDb
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public bool IsBorrowed { get; set; }

        public BookDb()
        {

        }

        public BookDb(int id, string title, bool isBorrowed)
        {
            (Id, Title, IsBorrowed) = (id, title, isBorrowed);
        }


    }
}
