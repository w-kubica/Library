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

        public BorrowedRepository(LibraryContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<Borrowed>> GetAllAsync()
        {
            var borrowed = await _context.Borrowed.ToListAsync();
            return borrowed.Select(a => a.ToDomain());
        }

        public async Task<Borrowed> GetByIdAsync(int id)
        {
            var borrowed = await _context.Borrowed.SingleOrDefaultAsync(x => x.Id == id);
            if (borrowed != null) 
                return borrowed.ToDomain();
            throw new Exception($"There is no borrowed with id: {id}");
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
