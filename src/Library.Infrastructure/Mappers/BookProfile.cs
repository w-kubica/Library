using Library.Domain.Models;
using Library.Infrastructure.DTO;

namespace Library.Infrastructure.Mappers
{
    public static class BookProfile
    {
        public static BookDb ToInfrastructure(this Book book) =>
            new(book.Id, book.Title, book.IsBorrowed);

        public static Book ToDomain(this BookDb book) =>
            new(book.Id, book.Title, book.IsBorrowed);
    }
}
