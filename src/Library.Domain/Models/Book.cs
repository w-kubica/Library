namespace Library.Domain.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int TotalCopy { get; set; }
        public int BorrowedCopy { get; set; }
        public int ToBorrow { get; set; }

        public Book(int id, string title, int totalCopy, int borrowedCopy, int toBorrow)
        {
            (Id, Title, TotalCopy, BorrowedCopy, ToBorrow) = (id, title, totalCopy, borrowedCopy, toBorrow);
        }

        public Book(int id, string title, int totalCopy)
        {
            (Id, Title, TotalCopy) = (id, title, totalCopy);
        }

        public Book(string title, int totalCopy)
        {
            (Title, TotalCopy) = (title, totalCopy);
        }
    }
}
