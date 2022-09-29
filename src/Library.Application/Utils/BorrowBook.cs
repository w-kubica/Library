namespace Library.Application.Utils
{
    public static class BorrowBook
    {
        public static (DateTime issuedDate, DateTime dueDate, DateTime? dateReturned, int updateBorrowedCopy, int
            updateToBorrowCopy, bool isBorrowed) Borrow(int borrowedCopy, int booksToBorrow)
        {
            var issuedDate = ExternalSystemHelper.GetIssuedDate();

            var dueDate = ExternalSystemHelper.GetDueDate(issuedDate);

            DateTime? dateReturned = null;

            var updateBorrowedCopy = borrowedCopy + 1;
            var updateToBorrowCopy = booksToBorrow - 1;

            var isBorrowed = true;
            return (issuedDate, dueDate, dateReturned, updateBorrowedCopy, updateToBorrowCopy, isBorrowed);
        }
    }
}
