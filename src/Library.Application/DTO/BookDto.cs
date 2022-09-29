namespace Library.Application.DTO
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int TotalCopy { get; set; }
        public int BorrowedCopy { get; set; }
        public int ToBorrow { get; set; }

        public BookDto(int id, string title, int totalCopy, int borrowedCopy, int toBorrow)
        {
            (Id, Title, TotalCopy, BorrowedCopy, ToBorrow) = (id, title, totalCopy, borrowedCopy, toBorrow);
        }
    }
}
