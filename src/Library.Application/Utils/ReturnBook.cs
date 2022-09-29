using Library.Domain.Models;

namespace Library.Application.Utils
{
    public static class ReturnBook
    {
        public static (DateTime dateReturned, int daysOfDelay, decimal overdueFine, bool isCharged, bool isBorrowed, int
            updateBorrowedCopy, int updateToBorrowCopy) Return(Reader reader, Book book, Borrowed borrowed)
        {
            var readerType = reader.ReaderType;

            var bookToBorrow = book.ToBorrow;
            var borrowedCopy = book.BorrowedCopy;

            var issuedDate = borrowed.IssuedDate;
            var dueDate = borrowed.DueDate;

            var dateReturned = ExternalSystemHelper.GetDateReturned(issuedDate);

            var daysOfDelay = OverdueFineHelper.CalculateDaysOfDelay(dateReturned, dueDate);

            var overdueFine = OverdueFineHelper.Calculate(readerType, daysOfDelay);

            bool isCharged = ExternalSystemHelper.GetIsCharged(overdueFine);

            bool isBorrowed = false;

            var updateBorrowedCopy = borrowedCopy - 1;
            var updateToBorrowCopy = bookToBorrow + 1;

            return (dateReturned, daysOfDelay, overdueFine, isCharged, isBorrowed, updateBorrowedCopy, updateToBorrowCopy);
        }
    }
}
