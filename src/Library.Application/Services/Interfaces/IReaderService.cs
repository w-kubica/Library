using Library.Application.DTO;

namespace Library.Application.Services.Interfaces
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
