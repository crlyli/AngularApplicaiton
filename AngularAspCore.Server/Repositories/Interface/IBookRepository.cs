using AngularAspCore.Server.Data.Models;
using AngularAspCore.Server.Data.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace AngularAspCore.Server.Repositories.Interface
{
    public interface IBookRepository
    {
        Task<BookDataModel> CreateAsync(BookDto bookData);
        Task<List<BookDataModel>> GetBooks();
        Task<List<BookDataModel>> GetBooksById(int fId);
        Task<ActionResult<BookDataModel>> UpdateBookById(int id, BookDataModel bookData);
    }
}
