namespace Library.Domain.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
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
