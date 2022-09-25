using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsBorrowed { get; set; }

        public Book()
        {

        }

        public Book(int id, string title, bool isBorrowed)
        {
            (Id, Title, IsBorrowed) = (id, title, isBorrowed);
        }
    }
}
