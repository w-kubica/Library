using Library.Application.DTO;

namespace Library.Application.Repositories
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetBooksAsync();
        Task<BookDto> GetBookByIdAsync(int id);
        Task AddBookAsync(CreateBookDto book);
        Task UpdateBookAsync(UpdateBookDto book);
        Task DeleteBookAsync(int id);

    }
}
