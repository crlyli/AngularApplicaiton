using AngularAspCore.Database.Data.Models;
using AngularAspCore.Database.Data.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace AngularAspCore.Database.Repositories.Interface
{
    /// <summary>
    /// Book Repository
    /// </summary>
    public interface IBookRepository
    {
        /// <summary>
        /// Create book
        /// </summary>
        /// <param name="bookData">Book data object</param>
        /// <returns>Book Data Model used in database</returns>
        Task<BookDataModel> CreateAsync(BookDto bookData);

        /// <summary>
        /// Get list of books
        /// </summary>
        /// <returns></returns>
        Task<List<BookDataModel>> GetBooks();

        Task<bool> DeleteBook(int fId);
        Task<List<BookDataModel>> GetBooksById(int fId);
        Task<ActionResult<BookDataModel>> UpdateBookById(int id, BookDto bookData);
    }
}
