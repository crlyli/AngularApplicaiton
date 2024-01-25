using AngularAspCore.Server.Data.Models.Domain;

namespace AngularAspCore.Server.Data.Services
{
    public class BookService : IBookService
    {
        private readonly IData mBookData;
        public BookService(IData bookData) { 
            mBookData = bookData;
        }
        public IData AddBook(BookData newBook)
        {
            mBookData.BookDataList.Add(newBook);
            return mBookData;
        }

        public void DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public List<BookData> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public BookData GetBookById()
        {
            throw new NotImplementedException();
        }

        public void UpdateBooks(int id, BookData newBook)
        {
            throw new NotImplementedException();
        }
    }
}
