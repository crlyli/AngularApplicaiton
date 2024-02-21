
using AngularAspCore.Database;
using AngularAspCore.Database.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace AngularAspCore.Server.Controllers
{
    /// <summary>
    /// Books Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly IRepositoryWraper _repo;

        /// <summary>
        /// Books Controller Constructor
        /// </summary>
        /// <param name="repo"></param>
        public BooksController(IRepositoryWraper repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Add Book
        /// </summary>
        /// <param name="modeldata">Model data of book to add from api</param>
        [HttpPost]
        public async Task<IActionResult> AddBookAsync([FromBody] BookDataModel modeldata)
        {
            try
            {
                await _repo.BookRepository.Add(modeldata);
                return Ok("Book added sucessfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// Get Books
        /// </summary>
        /// <returns>List of books</returns>
        [HttpGet]
        public IActionResult GetBooksAsync()
        {
            try
            {
                var books = _repo.BookRepository.GetAll();
                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message);
            }
        }

        /// <summary>
        /// Delete Book by id
        /// </summary>
        /// <param name="id">Book id pk</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookAsync(int id)
        {
            try
            {
                await _repo.BookRepository.DeleteById(id);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message + "Error deleting data");
            }
            return Ok();
        }

        /// <summary>
        /// Update book -- TODO
        /// </summary>
        /// <param name="modeldata"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateBook([FromBody] BookDataModel modeldata)
        {
            try
            {
                await _repo.BookRepository.Update(modeldata);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message);
            }
           return Ok();
        }
    }
}

