using Library.Application.DTO;
using Library.Application.Mappers;
using Library.Application.Repositories;
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

        public async Task AddBookAsync(BookDto book)
        {
            var newbook = book.ToDomain();
            await _bookRepository.AddAsync(newbook);
        }

        public async Task UpdateBookAsync(BookDto book)
        {
            var updatebook = book.ToDomain();
            await _bookRepository.UpdateAsync(updatebook);
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            await _bookRepository.DeleteAsync(book);
        }
    }
}
