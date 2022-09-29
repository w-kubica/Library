using Library.Application.DTO;
using Library.Application.Mappers;
using Library.Application.Services.Interfaces;
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
            var pesel = newReader.Pesel;
            if (string.IsNullOrEmpty(newReader.Pesel))
            {
                throw new Exception("Reader cannot have an empty pesel.");
            }

            var peselArr = pesel.ToArray();
            if (pesel.Length != 11)
            {
                throw new Exception("Invalid pesel.");
            }

            var t = IsDigit(peselArr);
            if (!t)
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

        private static bool IsDigit(char[] peselArr)
        {
            bool t = true;
            foreach (char ch in peselArr)
            {
                if (!char.IsDigit(ch))
                {
                    t = false;
                    break;
                }
            }
            return t;
        }

        public async Task UpdateReaderAsync(UpdateReaderDto reader)
        {
            var existingReader = await _readerRepository.GetByIdAsync(reader.Id);
            var existingReaderType = (int)existingReader.ReaderType;

            var newReaderType = reader.ReaderType;

            var readerTypes = ReaderTypeService.AssignDic();

            ReaderTypeService.Assign(readerTypes, existingReaderType, newReaderType, existingReader);

            await _readerRepository.UpdateAsync(existingReader);
        }

        public async Task DeleteReaderAsync(int id)
        {
            var reader = await _readerRepository.GetByIdAsync(id);
            await _readerRepository.DeleteAsync(reader);
        }
    }
}
