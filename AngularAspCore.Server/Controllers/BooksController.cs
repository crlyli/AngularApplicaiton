
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
                if (modeldata is null)
                    return BadRequest("Owner object is null");
                else
                    _repo.BookRepository.Add(modeldata);
                    await _repo.SaveAsync();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message);
            }           

            return Ok();
        }

        /// <summary>
        /// Get Books
        /// </summary>
        /// <returns>List of books</returns>
        [HttpGet]
        public IEnumerable<BookDataModel> GetBooksAsync()
        {
            return _repo.BookRepository.GetAll();
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
                _repo.BookRepository.DeleteById(id);
                await _repo.SaveAsync();

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
                _repo.BookRepository.Update(modeldata);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
           return Ok();
        }
    }
}

