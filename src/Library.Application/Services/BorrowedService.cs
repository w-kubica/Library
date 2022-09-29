using Library.Application.DTO;
using Library.Application.Mappers;
using Library.Application.Services.Interfaces;
using Library.Application.Utils;
using Library.Domain.Repositories;

namespace Library.Application.Services
{
    public class BorrowedService : IBorrowedService
    {
        private readonly IBorrowedRepository _borrowedRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IReaderRepository _readerRepository;
        private readonly IDataValidatorService _dataValidatorService;

        public BorrowedService(IBorrowedRepository borrowedRepository, IBookRepository bookRepository, IReaderRepository readerRepository, IDataValidatorService dataValidatorService)
        {
            _borrowedRepository = borrowedRepository;
            _bookRepository = bookRepository;
            _readerRepository = readerRepository;
            _dataValidatorService = dataValidatorService;
        }

        public async Task<IEnumerable<BorrowedDto>> GetBorrowedAsync()
        {
            var borrowed = await _borrowedRepository.GetAllAsync();
            return borrowed.Select(a => a.ToApplication());
        }

        public async Task<BorrowedDto> GetBorrowedByIdAsync(int id)
        {
            var borrowed = await _borrowedRepository.GetByIdAsync(id);
            return borrowed.ToApplication();
        }

        public async Task AddBorrowedAsync(CreateBorrowedDto borrowed)
        {
            var dto = borrowed.ToDomain();
            var isReaderExists = await _dataValidatorService.IsReaderExists(dto.ReaderId);
            var isBookExists = await _dataValidatorService.IsBookExists(dto.BookId);

            if (isBookExists && isReaderExists)
            {
                var book = await _bookRepository.GetByIdAsync(borrowed.BookId);
                var booksToBorrow = book.ToBorrow;
                var borrowedCopy = book.BorrowedCopy;
                if (booksToBorrow > 0)
                {
                    (dto.IssuedDate, dto.DueDate, dto.DateReturned, book.BorrowedCopy, book.ToBorrow, dto.BorrowedStatus) = BorrowBook.Borrow(borrowedCopy, booksToBorrow);

                    await _borrowedRepository.AddAsync(dto);
                    await _bookRepository.UpdateAsync(book);
                }
                else
                {
                    throw new Exception("The book is already on loan.");
                }
            }
            else
            {
                throw new Exception("Invalid book or reader.");
            }
        }

        public async Task UpdateBorrowedAsync(UpdateBorrowedDto updateBorrowed)
        {
            var dto = updateBorrowed.ToDomain();
            var isBorrowedExists = await _dataValidatorService.IsBorrowedExists(dto.Id);

            if (isBorrowedExists)
            {
                var borrowedId = updateBorrowed.Id;

                var borrowed = await _borrowedRepository.GetByIdAsync(borrowedId);
                if (borrowed.BorrowedStatus)
                {
                    var book = await _bookRepository.GetByIdAsync(borrowed.BookId);

                    var reader = await _readerRepository.GetByIdAsync(borrowed.ReaderId);

                    // todo: change to objects

                    (borrowed.DateReturned, borrowed.DaysOfDelay, borrowed.OverdueFine, borrowed.IsCharged, borrowed.BorrowedStatus,
                        book.BorrowedCopy, book.ToBorrow) = ReturnBook.Return(reader, book, borrowed);

                    await _borrowedRepository.UpdateAsync(borrowed);
                    await _bookRepository.UpdateAsync(book);
                }
                else
                {
                    throw new Exception("The book has already been returned.");
                }
            }
            else
            {
                throw new Exception("Borrow not exist.");
            }
        }

        public async Task DeleteBorrowedAsync(int id)
        {
            var borrow = await _borrowedRepository.GetByIdAsync(id);
            await _borrowedRepository.DeleteAsync(borrow);
        }
    }
}
