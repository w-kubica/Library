using Library.Domain.Models;

namespace Library.Application.DTO
{
    public class CreateReaderDto
    {
        public string Pesel { get; set; }
        public ReaderType ReaderType { get; set; }

        public CreateReaderDto(string pesel, ReaderType readerType)
        {
            (Pesel, ReaderType) = (pesel, readerType);
        }

        public CreateReaderDto()
        {

        }
    }


}
