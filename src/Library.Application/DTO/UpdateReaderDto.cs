using Library.Domain.Models;

namespace Library.Application.DTO
{
    public class UpdateReaderDto
    {
        public int Id { get; set; }
        public ReaderType ReaderType { get; set; }
    }
}
