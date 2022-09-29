using Library.Domain.Models;

namespace Library.Application.Services.Interfaces;

public interface IOverdueFineService
{
    static int CalculateDaysOfDelay(DateTime dateReturned, DateTime dueDate) => throw new NotImplementedException();
    static decimal Calculate(ReaderType readerType, int daysOfDelay) => throw new NotImplementedException();
    static decimal ForEmployees(int daysOfDelay) => throw new NotImplementedException();
    static decimal ForStudents(int daysOfDelay) => throw new NotImplementedException();
    static decimal ForLecturers(int daysOfDelay) => throw new NotImplementedException();
}