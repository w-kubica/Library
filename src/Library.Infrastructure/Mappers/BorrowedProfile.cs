using Library.Domain.Models;
using Library.Infrastructure.DTO;

namespace Library.Infrastructure.Mappers
{
    public static class BorrowedProfile
    {
        public static BorrowedDb ToInfrastructure(this Borrowed borrowed) =>
            new(borrowed.Id, borrowed.ReaderId, borrowed.BookId, borrowed.IssuedDate, borrowed.DueDate, borrowed.DateReturned, borrowed.BorrowedStatus, borrowed.DaysOfDelay, borrowed.OverdueFine, borrowed.IsCharged);

        public static Borrowed ToDomain (this BorrowedDb borrowed) =>
            new(borrowed.Id, borrowed.ReaderId, borrowed.BookId, borrowed.IssuedDate, borrowed.DueDate, borrowed.DateReturned, borrowed.BorrowedStatus, borrowed.DaysOfDelay, borrowed.OverdueFine, borrowed.IsCharged);
    }
}
