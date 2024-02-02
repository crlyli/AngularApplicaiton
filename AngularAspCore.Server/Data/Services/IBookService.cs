using AngularAspCore.Server.Data.Models.Domain;

namespace AngularAspCore.Server.Data.Services
{
    public interface IBookService
    {
        List<BookData> GetAllBooks();
        BookData GetBookById();
        void UpdateBooks(int id, BookData newBook);
        void DeleteBook(int id);
        IData AddBook(BookData newBook);
    }
}
