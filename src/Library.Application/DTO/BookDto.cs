namespace Library.Application.DTO
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsBorrowed { get; set; }

        public BookDto()
        {

        }

        public BookDto(int id, string title, bool isBorrowed)
        {
            (Id, Title, IsBorrowed) = (id, title, isBorrowed);
        }
    }
}
