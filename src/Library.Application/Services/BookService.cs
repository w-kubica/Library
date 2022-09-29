using Library.Application.DTO;
using Library.Application.Mappers;
using Library.Application.Services.Interfaces;
using Library.Domain.Repositories;


namespace Library.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<IEnumerable<BookDto>> GetBooksAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            return books.Select(a => a.ToApplication());
        }

        public async Task<BookDto> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            return book.ToApplication();
        }

        public async Task AddBookAsync(CreateBookDto book)
        {
            var newbook = book.ToDomain();
            if (book.TotalCopy > 0)
            {
                newbook.BorrowedCopy = 0;
                newbook.ToBorrow = newbook.TotalCopy - newbook.BorrowedCopy;
                await _bookRepository.AddAsync(newbook);
            }
            else
            {
                throw new Exception("Please enter a valid value.");
            }
        }

        public async Task UpdateBookAsync(UpdateBookDto book)
        {
            var dto = book.ToDomain();
            if (dto.TotalCopy > 0)
            {
                var existingbook = await _bookRepository.GetByIdAsync(book.Id);
                dto.ToBorrow = dto.TotalCopy - existingbook.BorrowedCopy;
                await _bookRepository.UpdateAsync(dto);
            }
            else
            {
                throw new Exception("Please enter a valid value.");
            }

        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            await _bookRepository.DeleteAsync(book);
        }
    }
}
