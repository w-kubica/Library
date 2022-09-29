namespace Library.Application.DTO
{
    public class CreateBorrowedDto
    {
        public int ReaderId { get; set; }
        public int BookId { get; set; }

        public CreateBorrowedDto(int readerId, int bookId)
        {
            (ReaderId, BookId) = (readerId, bookId);
        }

        public CreateBorrowedDto()
        {

        }
    }
}
