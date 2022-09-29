using Library.Domain.Models;

namespace Library.Application.DTO
{
    public class CreateReaderDto
    {
        public string Pesel { get; set; }
        public ReaderType ReaderType { get; set; }
    }


}
