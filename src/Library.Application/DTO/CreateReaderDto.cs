using Library.Domain.Models;
#pragma warning disable CS8618

namespace Library.Application.DTO
{
    public class CreateReaderDto
    {
        public string Pesel { get; set; }
        public ReaderType ReaderType { get; set; }
    }


}
