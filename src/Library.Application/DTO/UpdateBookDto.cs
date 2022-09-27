namespace Library.Application.DTO
{
    public class UpdateBookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int TotalCopy { get; set; }
        public UpdateBookDto()
        {

        }

        public UpdateBookDto(int id, string title, int totalCopy)
        {
            (Id, Title, TotalCopy) = (id, title, totalCopy);
        }
    }
}
