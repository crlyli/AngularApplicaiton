using AngularAspCore.Server.Data.Models;
using AngularAspCore.Server.Data.Models.Domain;
using AngularAspCore.Server.Data.Models.Dto;
using AngularAspCore.Server.Data.Services;
using AngularAspCore.Server.Repositories.DbContextData;
using AngularAspCore.Server.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AngularAspCore.Server.Controllers
{
    [Route("api/controller")]
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IBookRepository _bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddBookAsync(CreateBookDto request)
        {
            //Map dto to Domain Model
            var book = new BookData()
            {
                Title = request.Title,
                Description = request.Description,
                Author = request.Author,
                Rate = request.Rate,
                DateStart = request.DateStart,
                DateRead = request.DateRead
            };
            await _bookRepository.CreateAsync(book);

            var domainModel = new BookDto()
            {
                Id = book.Id,
                Title = book.Title,
                Description = book.Description,
                Author = book.Author,
                Rate = book.Rate,
                DateStart = book.DateStart,
                DateRead = book.DateRead
            };
            return Ok(domainModel);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBooksAsync()
        {
            var allBooks = _bookService.GetAllBooks();
            return Ok(allBooks);
        }
    }
}
