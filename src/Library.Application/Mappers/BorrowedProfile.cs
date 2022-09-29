using Library.Application.DTO;
using Library.Domain.Models;

namespace Library.Application.Mappers
{
    public static class BorrowedProfile
    {
        public static BorrowedDto ToApplication(this Borrowed borrowed) =>
            new(borrowed.Id, borrowed.ReaderId, borrowed.BookId, borrowed.IssuedDate, borrowed.DueDate, borrowed.DateReturned, borrowed.BorrowedStatus, borrowed.DaysOfDelay, borrowed.OverdueFine, borrowed.IsCharged);

        public static Borrowed ToDomain(this BorrowedDto borrowed) =>
            new(borrowed.Id, borrowed.ReaderId, borrowed.BookId, borrowed.IssuedDate, borrowed.DueDate, borrowed.DateReturned, borrowed.BorrowedStatus, borrowed.DaysOfDelay, borrowed.OverdueFine, borrowed.IsCharged);

        public static Borrowed ToDomain(this CreateBorrowedDto borrowed) =>
            new(borrowed.Id, borrowed.ReaderId, borrowed.BookId);
        public static Borrowed ToDomain(this UpdateBorrowedDto borrowed) =>
            new(borrowed.Id);
    }
}
