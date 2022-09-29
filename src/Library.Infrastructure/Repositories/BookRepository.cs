using Library.Domain.Models;
using Library.Domain.Repositories;
using Library.Infrastructure.Data;
using Library.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;

        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            var books = await _context.Books.ToListAsync();
            return books.Select(a => a.ToDomain());
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            var book = await _context.Books.SingleOrDefaultAsync(x => x.Id == id);
            return book.ToDomain();
        }

        public async Task AddAsync(Book book)
        {
            var dto = book.ToInfrastructure();
            await _context.Books.AddAsync(dto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            var dto = book.ToInfrastructure();
            _context.Books.Update(dto);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Book book)
        {
            var dto = book.ToInfrastructure();
            _context.Books.Remove(dto);
            await _context.SaveChangesAsync();
        }
    }
}
