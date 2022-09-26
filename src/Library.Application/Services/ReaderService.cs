using Library.Application.Mappers;
using Library.Domain.Repositories;
using Library.Infrastructure.DTO;

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
            await _readerRepository.AddAsync(newReader);

        }

        public async Task UpdateReaderAsync(ReaderDto reader)
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
