namespace Library.Infrastructure.DTO
{
    public class BookDb
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int TotalCopy { get; set; }
        public int BorrowedCopy { get; set; }
        public int ToBorrow { get; set; }
        public List<BorrowedDb> Borrowed { get; set; } = new List<BorrowedDb>();

        public int SetToBorrow(int totalCopy, int borrowedCopy, int toBorrow)
        {
            TotalCopy = totalCopy;
            BorrowedCopy = borrowedCopy;
            toBorrow = totalCopy - borrowedCopy;
            ToBorrow = toBorrow;
            return ToBorrow;
        }

        public BookDb()
        {

        }

        public BookDb(int id, string title, int totalCopy, int borrowedCopy, int toBorrow)
        {
            (Id, Title, TotalCopy, BorrowedCopy, ToBorrow) = (id, title, totalCopy, borrowedCopy, SetToBorrow(totalCopy, borrowedCopy, toBorrow));
        }
        

    }
}
