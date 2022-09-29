using Library.Application.DTO;

namespace Library.Application.Repositories
{
    public interface IBorrowedService
    {
        Task<IEnumerable<BorrowedDto>> GetBorrowedAsync();
        Task<BorrowedDto> GetBorrowedByIdAsync(int id);
        Task AddBorrowedAsync(CreateBorrowedDto borrowed);
        Task UpdateBorrowedAsync(UpdateBorrowedDto borrowed);
        Task DeleteBorrowedAsync(int id);

    }
}
