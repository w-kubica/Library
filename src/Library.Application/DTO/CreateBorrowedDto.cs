namespace Library.Application.DTO
{
    public class CreateBorrowedDto
    {
        public int Id { get; set; }
        public int ReaderId { get; set; }
        public int BookId { get; set; }

        public CreateBorrowedDto(int id, int readerId, int bookId)
        {
            (Id, ReaderId, BookId) = (id, readerId, bookId);
        }

        public CreateBorrowedDto()
        {

        }
    }
}
