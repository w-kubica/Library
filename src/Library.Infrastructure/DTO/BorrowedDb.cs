using System.ComponentModel.DataAnnotations;

namespace Library.Infrastructure.DTO
{
    public class BorrowedDb
    {
        [Key]
        public int Id { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime DateReturned { get; set; }
        public bool BorrowedStatus { get; set; }
        public int DaysOfDelay { get; set; }
        public decimal OverdueFine { get; set; }
        public bool IsCharged { get; set; }
        public ReaderDb Reader { get; set; }
        public BookDb Book { get; set; }
        public BorrowedDb(int id, int readerId, int bookId, DateTime issuedDate, DateTime dueDate, DateTime dateReturned, bool borrowedStatus, int daysOfDelay, decimal overdueFine, bool isCharged)
        {
            (Id, IssuedDate, DueDate, DateReturned, BorrowedStatus, DaysOfDelay, OverdueFine,
                IsCharged) = (id, issuedDate, dueDate, dateReturned, borrowedStatus, daysOfDelay,
                overdueFine, isCharged);
        }

        public BorrowedDb()
        {

        }

        private Random gen = new Random();
        DateTime RandomDay()
        {
            DateTime start = new DateTime(2022, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }

        public DateTime SetIssuedDate()
        {
            IssuedDate = RandomDay();
            return IssuedDate;
        }

        public DateTime SetDueDate()
        {
            DueDate = SetIssuedDate().AddDays(60);
            return DueDate;
        }

        public DateTime SetDateReturned()
        {
            var random = new Random();
            DueDate = SetIssuedDate().AddDays(random.Next(55, 100));
            return DueDate;
        }

        public bool SetBorrowedStatus(DateTime dateReturned)
        {
            bool borrowedStatus;
            DateReturned = dateReturned;
            var today = DateTime.Today;

            if (today > DateReturned)
            {
                borrowedStatus = false;
            }
            else
            {
                borrowedStatus = true;
            }

            return borrowedStatus;
        }
    }
}
