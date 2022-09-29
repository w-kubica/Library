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
            var readerIsExists = await _dataValidatorService.ReaderIsExists(dto.ReaderId);
            var bookIsExists = await _dataValidatorService.BookIsExists(dto.BookId);

            if (bookIsExists && readerIsExists)
            {
                var book = await _bookRepository.GetByIdAsync(borrowed.BookId);
                var booksToBorrow = book.ToBorrow;
                var borrowedCopy = book.BorrowedCopy;
                if (booksToBorrow > 0)
                {
                    var (issuedDate, dueDate, dateReturned, updateBorrowedCopy, updateToBorrowCopy, isBorrowed) = BorrowBook.Borrow(borrowedCopy, booksToBorrow);

                    dto.IssuedDate = issuedDate;
                    dto.DueDate = dueDate;
                    dto.DateReturned = dateReturned;
                    dto.BorrowedStatus = isBorrowed;

                    book.BorrowedCopy = updateBorrowedCopy;
                    book.ToBorrow = updateToBorrowCopy;

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
            var borrowedIsExists = await _dataValidatorService.BorrowedIsExists(dto.Id);

            if (borrowedIsExists)
            {
                var borrowedId = updateBorrowed.Id;

                var borrowed = await _borrowedRepository.GetByIdAsync(borrowedId);
                if (borrowed.BorrowedStatus)
                {
                    var book = await _bookRepository.GetByIdAsync(borrowed.BookId);

                    var reader = await _readerRepository.GetByIdAsync(borrowed.ReaderId);
                    var (dateReturned, daysOfDelay, overdueFine, isCharged, isBorrowed, updateBorrowedCopy, updateToBorrowCopy) = ReturnBook.Return(reader, book, borrowed);

                    borrowed.DateReturned = dateReturned;
                    borrowed.DaysOfDelay = daysOfDelay;
                    borrowed.OverdueFine = overdueFine;
                    borrowed.IsCharged = isCharged;
                    borrowed.BorrowedStatus = isBorrowed;

                    book.BorrowedCopy = updateBorrowedCopy;
                    book.ToBorrow = updateToBorrowCopy;

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
