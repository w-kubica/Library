using Library.Domain.Models;

namespace Library.Domain.Repositories
{
    public interface IReaderRepository
    {
        Task<IEnumerable<Reader>> GetAllAsync();
        Task<Reader> GetByIdAsync(int id);
        Task<Reader> AddAsync(Reader reader);
        Task UpdateAsync(Reader reader);
        Task DeleteAsync(Reader reader);
    }
}
