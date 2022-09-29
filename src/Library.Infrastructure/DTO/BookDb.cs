#pragma warning disable CS8618
namespace Library.Infrastructure.DTO
{
    public class BookDb
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int TotalCopy { get; set; }
        public int BorrowedCopy { get; set; }
        public int ToBorrow { get; set; }
        public List<BorrowedDb> Borrowed { get; set; } = new();

        private int SetToBorrow(int totalCopy, int borrowedCopy)
        {
            TotalCopy = totalCopy;
            BorrowedCopy = borrowedCopy;
            ToBorrow = totalCopy - borrowedCopy;
            return ToBorrow;
        }

        public BookDb()
        {

        }

        public BookDb(int id, string title, int totalCopy, int borrowedCopy)
        {
            (Id, Title, TotalCopy, BorrowedCopy, ToBorrow) = (id, title, totalCopy, borrowedCopy, SetToBorrow(totalCopy, borrowedCopy));
        }
        

    }
}
