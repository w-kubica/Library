using Library.Application.DTO;
using Library.Domain.Models;

namespace Library.Application.Services.Interfaces;

public interface IBorrowedValidator
{
    Task<bool> ReaderIsExists(Borrowed borrowed);
    Task<bool> BookIsExists(Borrowed borrowed);
    Task<bool> BorrowedIsExists(Borrowed borrowed);
}