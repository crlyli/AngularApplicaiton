
using AngularAspCore.Database;
using AngularAspCore.Database.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace AngularAspCore.Server.Controllers
{
    /// <summary>
    /// Reader Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ReaderController : Controller
    {
        private readonly IRepositoryWraper _repo;
        
        /// <summary>
        /// Reader Controller Constructor
        /// </summary>
        public ReaderController(IRepositoryWraper repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Add Reader
        /// </summary>
        /// <param name="modeldata">Reader model data to add</param>
        [HttpPost]
        public async Task<IActionResult> AddReaderAsync([FromBody] ReaderDataModel modeldata)
        {
            try
            {
                if (modeldata is null)
                    return BadRequest("Reader object is null");
                else
                    await _repo.ReaderRepository.Add(modeldata);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message);
            }
            return CreatedAtAction(nameof(GetReader), new { id = modeldata.Id }, modeldata);
        }

        /// <summary>
        /// Get Readers
        /// </summary>
        /// <returns>List of all readers</returns>
        [HttpGet]
        public IActionResult GetReadersAsync()
        {
            try
            {
                var readers = _repo.ReaderRepository.GetAll();
                return Ok(readers);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message);
            }
        }

        /// <summary>
        /// Get Reader by Id
        /// </summary>
        /// <param name="id">Unique id</param>
        /// <returns>Reader with id or bad result</returns>
        [HttpGet("{id:int}")]
        public ActionResult GetReader(int id)
        {
            try
            {
                var result = _repo.ReaderRepository.GetById(id);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        /// <summary>
        /// Delete reader by id
        /// </summary>
        /// <param name="id">Reader id pk</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReaderAsync(int id)
        {
            try
            {
                await _repo.ReaderRepository.DeleteById(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message + "Error deleting data");
            }
            return Ok();
        }

        /// <summary>
        /// Update Reader TODO
        /// </summary>
        /// <param name="modeldata"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateReaderAsync([FromBody] ReaderDataModel modeldata)
        {
            try
            {
                await _repo.ReaderRepository.Update(modeldata);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating data");
            }
            return Ok();
        }
    }
}

