namespace Library.Application.Services.Interfaces;

public interface IDataValidatorService
{
    Task<bool> ReaderIsExists(int readerId);
    Task<bool> BookIsExists(int bookId);
    Task<bool> BorrowedIsExists(int borrowedId);
}