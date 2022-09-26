using Library.Application.DTO;
using Library.Domain.Models;

namespace Library.Application.Mappers
{
    public static class BookProfile
    {
        public static BookDto ToApplication(this Book book) =>
            new(book.Id, book.Title, book.IsBorrowed);
        public static Book ToDomain(this BookDto book) =>
            new(book.Id, book.Title, book.IsBorrowed);
    }
}
