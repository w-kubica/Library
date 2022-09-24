using Library.Domain.Models;

namespace Library.Domain.Repositories
{
    public interface IBorrowedRepository
    {
        Task<IEnumerable<Borrowed>> GetAllAsync();
        Task<Borrowed> GetByIdAsync(int id);
        Task<Borrowed> AddAsync(Borrowed borrowed);
        Task UpdateAsync(Borrowed borrowed);
        Task DeleteAsync(Borrowed borrowed);
    }
}
