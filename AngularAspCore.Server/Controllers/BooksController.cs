
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
        public async Task<IActionResult> AddBookAsync([FromBody] BookDto modeldata)
        {
            //Map dto to Domain Model
            if (modeldata is null)
            {
                //_logger.LogError("Owner object sent from client is null.");
                return BadRequest("Owner object is null");
            }

            await _bookRepository.CreateAsync(modeldata);


            return Ok(modeldata);
        }

        [HttpGet]
        public async Task<IActionResult> GetBooksAsync()
        {
            var allBooks = await _bookRepository.GetBooks();
            return Ok(allBooks);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBookAsync(int id)
        {
            try
            {
                var book = await _bookRepository.DeleteBook(id);

                return book == false ? NotFound($"Book with Id = {id} not found") : Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }

        [HttpPatch]
        [Route("{id:int}")]
        public async Task<IActionResult> GetBookByIdAsync(int fId, [FromBody] BookDto modeldata)
        {
            var allBooks = await _bookRepository.UpdateBookById(fId, modeldata);
            if (allBooks == null)
                return BadRequest();

            return Ok(allBooks);
        }
    }
}

