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
        private readonly IBorrowedValidator _borrowedValidator;

        public BorrowedService(IBorrowedRepository borrowedRepository, IBookRepository bookRepository, IReaderRepository readerRepository, IBorrowedValidator borrowedValidator)
        {
            _borrowedRepository = borrowedRepository;
            _bookRepository = bookRepository;
            _readerRepository = readerRepository;
            _borrowedValidator = borrowedValidator;
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
            var readerIsExist = await _borrowedValidator.ReaderIsExists(borrowed.ToDomain());

            var bookIsExist = await _borrowedValidator.BookIsExists(borrowed.ToDomain());

            if (bookIsExist && readerIsExist)
            {
                var book = await _bookRepository.GetByIdAsync(borrowed.BookId);
                var bookToBorrow = book.ToBorrow;
                var borrowedCopy = book.BorrowedCopy;
                if (bookToBorrow > 0)
                {
                    var issuedDate = ExternalSystemHelper.GetIssuedDate();

                    var dueDate = ExternalSystemHelper.GetDueDate(issuedDate);

                    DateTime? dateReturned = null;

                    var dto = borrowed.ToDomain();
                    var bookdto = book;

                    dto.IssuedDate = issuedDate;
                    dto.DueDate = dueDate;
                    dto.DateReturned = dateReturned;
                    dto.BorrowedStatus = true;

                    bookdto.BorrowedCopy = borrowedCopy + 1;
                    bookdto.ToBorrow = bookToBorrow - 1;

                    await _borrowedRepository.AddAsync(dto);
                    await _bookRepository.UpdateAsync(bookdto);
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
            var borrowedIsExists = await _borrowedValidator.BorrowedIsExists(updateBorrowed.ToDomain());

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
