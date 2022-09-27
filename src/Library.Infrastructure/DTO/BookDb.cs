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
        public int TotalCopy { get; set; }
        public int BorrowedCopy { get; set; }
        public int ToBorrow { get; set; }

        public int SetToBorrow(int totalCopy, int borrowedCopy, int toBorrow)
        {
            TotalCopy = totalCopy;
            BorrowedCopy = borrowedCopy;
            toBorrow = totalCopy - borrowedCopy;
            ToBorrow = toBorrow;
            return ToBorrow;
        }

        public BookDb()
        {

        }

        public BookDb(int id, string title, int totalCopy, int borrowedCopy, int toBorrow)
        {
            (Id, Title, TotalCopy, BorrowedCopy, ToBorrow) = (id, title, totalCopy, borrowedCopy, SetToBorrow(totalCopy,borrowedCopy,toBorrow));
        }

        public BookDb(int id, string title, int totalCopy)
        {
            (Id, Title, TotalCopy) = (id, title, totalCopy);
        }

    }
}
