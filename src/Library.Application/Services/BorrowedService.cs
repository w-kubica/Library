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


        public BorrowedService(IBorrowedRepository borrowedRepository, IBookRepository bookRepository, IReaderRepository readerRepository)
        {
            _borrowedRepository = borrowedRepository;
            _bookRepository = bookRepository;
            _readerRepository = readerRepository;
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
            //var newborrowed = borrowed.ToDomain();
            //await _borrowedRepository.AddAsync(newborrowed);

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

        public async Task UpdateBorrowedAsync(UpdateBorrowedDto updateBorrowed)
        {
            //var updateBorrowed = borrowed.ToDomain();
            //await _borrowedRepository.UpdateAsync(updateBorrowed);

            var borrowedId = updateBorrowed.Id;

            var borrowed = await _borrowedRepository.GetByIdAsync(borrowedId);

            var book = await _bookRepository.GetByIdAsync(borrowed.BookId);

            var reader = await _readerRepository.GetByIdAsync(borrowed.ReaderId);
            var readerType = reader.ReaderType;

            var bookToBorrow = book.ToBorrow;
            var borrowedCopy = book.BorrowedCopy;

            var issuedDate = borrowed.IssuedDate;
            var dueDate = borrowed.DueDate;

            var dateReturned = ExternalSystemHelper.GetDateReturned(issuedDate);

            var daysOfDelay = OverdueFineHelper.CalculateDaysOfDelay(dateReturned, dueDate);

            var overdueFine = OverdueFineHelper.Calculate(readerType, daysOfDelay);

            bool isCharged = ExternalSystemHelper.GetIsCharged(overdueFine);

            borrowed.DateReturned = dateReturned;
            borrowed.DaysOfDelay = daysOfDelay;
            borrowed.OverdueFine = overdueFine;
            borrowed.IsCharged = isCharged;
            borrowed.BorrowedStatus = false;

            book.BorrowedCopy = borrowedCopy - 1;
            book.ToBorrow = bookToBorrow + 1;

            await _borrowedRepository.UpdateAsync(borrowed);
            await _bookRepository.UpdateAsync(book);
        }

        public async Task DeleteBorrowedAsync(int id)
        {
            var borrow = await _borrowedRepository.GetByIdAsync(id);
            await _borrowedRepository.DeleteAsync(borrow);
        }
    }
}
