using Library.Application.Services.Interfaces;
using Library.Domain.Repositories;

namespace Library.Application.Services
{
    public class DataValidatorService : IDataValidatorService
    {
        private readonly IReaderRepository _readerRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IBorrowedRepository _borrowedRepository;

        public DataValidatorService(IReaderRepository readerRepository, IBookRepository bookRepository, IBorrowedRepository borrowedRepository)
        {
            _readerRepository = readerRepository;
            _bookRepository = bookRepository;
            _borrowedRepository = borrowedRepository;
        }

        public async Task<bool> IsReaderExists(int readerId)
        {
            var readers = await _readerRepository.GetAllAsync();
            var readerIsExist = readers.Any(r => r.Id == readerId);
            return readerIsExist;
        }

        public async Task<bool> IsBookExists(int bookId)
        {
            var books = await _bookRepository.GetAllAsync();
            var bookIsExist = books.Any(a => a.Id == bookId);
            return bookIsExist;
        }

        public async Task<bool> IsBorrowedExists(int borrowedId)
        {
            var borrowed = await _borrowedRepository.GetAllAsync();
            var borrowedIsExist = borrowed.Any(a => a.Id == borrowedId);
            return borrowedIsExist;
        }
    }
}
