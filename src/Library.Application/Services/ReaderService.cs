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
        private readonly IDataValidatorService _dataValidatorService;

        public ReaderService(IReaderRepository readerRepository, IDataValidatorService dataValidatorService)
        {
            _readerRepository = readerRepository;
            _dataValidatorService = dataValidatorService;
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

            var isValid = pesel.IsValidPesel();

            if (!isValid)
            {
                throw new Exception("Invalid pesel.");
            }

            // todo: move to infra
            var readers = await _readerRepository.GetAllAsync();

            if (readers.Any(a => a.Pesel == newReader.Pesel))
            {
                throw new Exception("This reader already exists.");
            }

            await _readerRepository.AddAsync(newReader);
        }

        public async Task UpdateReaderAsync(UpdateReaderDto reader)
        {
            var dto = reader.ToDomain();
            var isReaderExists = await _dataValidatorService.IsReaderExists(dto.Id);

            if (isReaderExists)
            {
                var existingReader = await _readerRepository.GetByIdAsync(reader.Id);

                var existingReaderType = existingReader.ReaderType;
                var newReaderType = reader.ReaderType;

                var isAssign = ReaderTypeHelper.Assign(ReaderTypeHelper.PossibleReaderTypes(), existingReaderType, newReaderType, existingReader);
                if (isAssign)
                {
                    await _readerRepository.UpdateAsync(existingReader);
                }
                else
                {
                    //todo: move to helper, remove bool
                    throw new Exception("A role cannot be changed. Incorrect data.");
                }
            }
            else
            {
                throw new Exception("Reader does not exist.");
            }
        }

        public async Task DeleteReaderAsync(int id)
        {
            var reader = await _readerRepository.GetByIdAsync(id);
            await _readerRepository.DeleteAsync(reader);
        }
    }
}
