namespace Library.Application.Services.Interfaces;

public interface IExternalSystemService
{
    public static DateTime GettingDateReturned(DateTime issuedDate) => throw new NotImplementedException();
    public static DateTime GettingDueDate(DateTime issuedDate) => throw new NotImplementedException();
    public static DateTime GettingIssuedDate() => throw new NotImplementedException();
    public static bool GettingIsCharged(decimal overdueFine) => throw new NotImplementedException();
    public static DateTime RandomDay() => throw new NotImplementedException();
}