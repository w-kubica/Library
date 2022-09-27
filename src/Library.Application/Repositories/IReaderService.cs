using Library.Application.DTO;
using Library.Domain.Models;
using Library.Infrastructure.DTO;

namespace Library.Domain.Repositories
{
    public interface IReaderService
    {
        Task<IEnumerable<ReaderDto>> GetAllReadersAsync();
        Task<ReaderDto> GetReaderByIdAsync(int id);
        Task AddReaderAsync(ReaderDto reader);
        Task UpdateReaderAsync(UpdateReaderDto reader);
        Task DeleteReaderAsync(int id);

    }
}
