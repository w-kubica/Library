using Library.Application.DTO;
using Library.Application.Mappers;
using Library.Application.Repositories;
using Library.Domain.Repositories;

namespace Library.Application.Services
{
    public class ReaderService : IReaderService
    {
        private readonly IReaderRepository _readerRepository;

        public ReaderService(IReaderRepository readerRepository)
        {
            _readerRepository = readerRepository;
        }
        public async Task<IEnumerable<ReaderDto>> GetAllReadersAsync()
        {
            var readers = await _readerRepository.GetAllAsync();
            return readers.Select(a => a.ToApplication());
        }

        public async Task<ReaderDto> GetReaderByIdAsync(int id)
        {
            var reader = await _readerRepository.GetByIdAsync(id);
            return reader.ToApplication();
        }

        public async Task AddReaderAsync(ReaderDto reader)
        {
            var newReader = reader.ToDomain();
            if (string.IsNullOrEmpty(newReader.Pesel))
            {
                throw new Exception("Reader cannot have an empty pesel.");
            }

            var readers = await _readerRepository.GetAllAsync();

            if (readers.Any(a => a.Pesel == newReader.Pesel))
            {
                throw new Exception("This reader already exists.");
            }

            if (newReader.ReaderType == null)
            {
                throw new Exception("Reader cannot have an empty reader type.");
            }
            await _readerRepository.AddAsync(newReader);

        }

        //public async Task UpdateReaderAsync(ReaderDto reader)
        //{
        //    var updateReader = reader.ToDomain();
        //    await _readerRepository.UpdateAsync(updateReader);
        //}

        public async Task UpdateReaderAsync(UpdateReaderDto reader)
        {
            var updateReader = reader.ToDomain();
            await _readerRepository.UpdateAsync(updateReader);
        }

        public async Task DeleteReaderAsync(int id)
        {
            var reader = await _readerRepository.GetByIdAsync(id);
            await _readerRepository.DeleteAsync(reader);
        }
    }
}
