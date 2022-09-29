using Library.Application.Mappers;
using Library.Application.Repositories;
using Library.Domain.Models;
using Library.Domain.Repositories;
using Library.Infrastructure.Data;
using Library.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    public class BorrowedRepository : IBorrowedRepository
    {
        private readonly LibraryContext _context;
        private readonly IReaderRepository _readerRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IReaderService _readerService;

        public BorrowedRepository(LibraryContext context, IReaderRepository readerRepository, IBookRepository bookRepository, IReaderService readerService)
        {
            _context = context;
            _readerRepository = readerRepository;
            _bookRepository = bookRepository;
            _readerService = readerService;
        }
        public async Task<IEnumerable<Borrowed>> GetAllAsync()
        {
            var borrowed = await _context.Borrowed.ToListAsync();
            return borrowed.Select(a => a.ToDomain());
        }

        public async Task<Borrowed> GetByIdAsync(int id)
        {
            var borrowed = await _context.Borrowed.SingleOrDefaultAsync(x => x.Id == id);
            return borrowed.ToDomain();
        }

        public async Task AddAsync(Borrowed borrowed)
        {
            var dto = borrowed.ToInfrastructure();
            await _context.Borrowed.AddAsync(dto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Borrowed borrowed)
        {
            var dto = borrowed.ToInfrastructure();
             _context.Update(dto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Borrowed borrowed)
        {
            var dto = borrowed.ToInfrastructure();
            _context.Borrowed.Remove(dto);
            await _context.SaveChangesAsync();
        }
    }
}
