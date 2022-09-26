namespace Library.Infrastructure.DTO
{
    public class BorrowedDb
    {
        public int Id { get; set; }
        public int ReaderId { get; set; }
        public int BookId { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime DateReturned { get; set; }
        public bool BorrowedStatus { get; set; }
        public int DaysOfDelay { get; set; }
        public decimal OverdueFine { get; set; }
        public bool IsCharged { get; set; }

        public BorrowedDb(int id, int readerId, int bookId, DateTime issuedDate, DateTime dueDate, DateTime dateReturned, bool borrowedStatus, int daysOfDelay, decimal overdueFine, bool isCharged)
        {
            (Id, ReaderId, BookId, IssuedDate, DueDate, DateReturned, BorrowedStatus, DaysOfDelay, OverdueFine,
                IsCharged) = (id, readerId, bookId, issuedDate, dueDate, dateReturned, borrowedStatus, daysOfDelay,
                overdueFine, isCharged);
        }

        public BorrowedDb()
        {
            
        }
    }
}
