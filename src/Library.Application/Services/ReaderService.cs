using Library.Application.DTO;
using Library.Application.Mappers;
using Library.Application.Services.Interfaces;
using Library.Application.Utils;
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

        public async Task AddReaderAsync(CreateReaderDto reader)
        {
            var newReader = reader.ToDomain();
            var pesel = newReader.Pesel;

            var isValid = PeselValidatorHelper.IsValidPESEL(pesel);

            if (!isValid)
            {
                throw new Exception("Invalid pesel.");
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

        public async Task UpdateReaderAsync(UpdateReaderDto reader)
        {
            var existingReader = await _readerRepository.GetByIdAsync(reader.Id);
            var existingReaderType = (int)existingReader.ReaderType;

            var newReaderType = reader.ReaderType;

            var readerTypes = ReaderTypeHelper.AssignDic();

            var isAssign = ReaderTypeHelper.Assign(readerTypes, existingReaderType, newReaderType, existingReader);
            if (isAssign)
            {
                await _readerRepository.UpdateAsync(existingReader);
            }
            else
            {
                throw new Exception("A role cannot be changed. Incorrect data.");
            }
        }

        public async Task DeleteReaderAsync(int id)
        {
            var reader = await _readerRepository.GetByIdAsync(id);
            await _readerRepository.DeleteAsync(reader);
        }
    }
}
