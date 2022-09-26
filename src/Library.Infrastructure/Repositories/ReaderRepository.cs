using Library.Domain.Models;
using Library.Domain.Repositories;
using Library.Infrastructure.Data;
using Library.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    public class ReaderRepository : IReaderRepository
    {
        private readonly LibraryContext _context;

        public ReaderRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reader>> GetAllAsync()
        {
            var readers = await _context.Readers.ToListAsync();
            return readers.Select(a => a.ToDomain());
        }

        public async Task<Reader> GetByIdAsync(int id)
        {
            var reader = await _context.Readers.SingleOrDefaultAsync(x => x.Id == id);
            return reader.ToDomain();
        }

        public async Task AddAsync(Reader reader)
        {
            var dto = reader.ToInfrastructure();
            await _context.Readers.AddAsync(dto);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Reader reader)
        {
            var dto = reader.ToInfrastructure();
            _context.Readers.Update(dto);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Reader reader)
        {
            var dto = reader.ToInfrastructure();
            _context.Readers.Remove(dto);
            await _context.SaveChangesAsync();
        }
    }
}
