#pragma warning disable CS8618
namespace Library.Application.DTO
{
    public class UpdateBookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int TotalCopy { get; set; }
    }
}
