using Library.Domain.Models;

namespace Library.Application.DTO
{
    public class UpdateReaderDto
    {
        public int Id { get; set; }
        public ReaderType ReaderType { get; set; }

        public UpdateReaderDto(int id, ReaderType readerType)
        {
            (Id, ReaderType) = (id, readerType);
        }

        public UpdateReaderDto()
        {

        }
    }
}
