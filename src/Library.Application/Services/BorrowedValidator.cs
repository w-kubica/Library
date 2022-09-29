using Library.Application.Services.Interfaces;
using Library.Domain.Models;
using Library.Domain.Repositories;

namespace Library.Application.Services
{
    public class BorrowedValidator : IBorrowedValidator
    {
        private readonly IReaderRepository _readerRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IBorrowedRepository _borrowedRepository;

        public BorrowedValidator(IReaderRepository readerRepository, IBookRepository bookRepository, IBorrowedRepository borrowedRepository)
        {
            _readerRepository = readerRepository;
            _bookRepository = bookRepository;
            _borrowedRepository = borrowedRepository;
        }

        public async Task<bool> ReaderIsExists(Borrowed borrowed)
        {
            var readerId = borrowed.ReaderId;
            var readers = await _readerRepository.GetAllAsync();
            var readerIsExist = readers.Any(r => r.Id == readerId);
            return readerIsExist;
        }

        public async Task<bool> BookIsExists(Borrowed borrowed)
        {
            var bookId = borrowed.BookId;
            var books = await _bookRepository.GetAllAsync();
            var bookIsExist = books.Any(a => a.Id == bookId);
            return bookIsExist;
        }

        public async Task<bool> BorrowedIsExists(Borrowed borrowed)
        {
            var borrowedId = borrowed.Id;
            var borrowed_ = await _borrowedRepository.GetAllAsync();
            var borrowedIsExist = borrowed_.Any(a => a.Id == borrowedId);
            return borrowedIsExist;
        }
    }
}
