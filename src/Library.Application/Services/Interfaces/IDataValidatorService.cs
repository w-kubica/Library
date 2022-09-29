namespace Library.Application.Services.Interfaces;

public interface IDataValidatorService
{
    Task<bool> IsReaderExists(int readerId);
    Task<bool> IsBookExists(int bookId);
    Task<bool> IsBorrowedExists(int borrowedId);
}