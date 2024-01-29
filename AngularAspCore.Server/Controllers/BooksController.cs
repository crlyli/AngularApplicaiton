
using AngularAspCore.Server.Data.Models;
using AngularAspCore.Server.Data.Models.Dto;
using AngularAspCore.Server.Repositories.DbContextData;
using AngularAspCore.Server.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AngularAspCore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
     
        private readonly IBookRepository _bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddBookAsync(BookDto modeldata)
        {
            //Map dto to Domain Model

            await _bookRepository.CreateAsync(modeldata);


            return Ok(modeldata);
        }

        [HttpGet]
        [Route("books")]
        public async Task<IActionResult> GetBooksAsync()
        {
            var allBooks = await _bookRepository.GetBooks();
            return Ok(allBooks);
        }

        [HttpGet]
        [Route("book")]
        public async Task<IActionResult> GetBookByIdAsync(int fId)
        {
            var allBooks = await _bookRepository.GetBooksById(fId);
            if (allBooks == null)
                return BadRequest();

            return Ok(allBooks);
        }
    }
}

