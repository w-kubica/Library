namespace Library.Application.DTO
{
    public class CreateBookDto
    {
        public string Title { get; set; }
        public int TotalCopy { get; set; }
        public CreateBookDto()
        {

        }

        public CreateBookDto(string title, int totalCopy)
        {
            (Title, TotalCopy) = (title, totalCopy);
        }
    }
}
