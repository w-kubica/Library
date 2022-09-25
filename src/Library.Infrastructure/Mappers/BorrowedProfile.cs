using Library.Domain.Models;

namespace Library.Infrastructure.Mappers
{
    public static class BorrowedProfile
    {
        public static Borrowed ToInfrastructure(this BorrowedDb borrowed) =>
            new(borrowed.Id, borrowed.ReaderId, borrowed.BookId, borrowed.IssuedDate, borrowed.DueDate, borrowed.DateReturned, borrowed.BorrowedStatus, borrowed.DaysOfDelay, borrowed.OverdueFine, borrowed.IsCharged);

        public static BorrowedDb ToDomain(this Borrowed borrowed) =>
            new(borrowed.Id, borrowed.ReaderId, borrowed.BookId, borrowed.IssuedDate, borrowed.DueDate, borrowed.DateReturned, borrowed.BorrowedStatus, borrowed.DaysOfDelay, borrowed.OverdueFine, borrowed.IsCharged);
    }
}
