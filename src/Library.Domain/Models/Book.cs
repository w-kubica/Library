using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Models
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public int TotalCopy { get; set; }

        public int BorrowedCopy { get; set; }

        public Book()
        {
            
        }

        public Book(int id, string title, int totalCopy, int borrowedCopy)
        {
            (Id, Title, TotalCopy, BorrowedCopy) = (id, title, totalCopy, borrowedCopy);
        }
    }
}
