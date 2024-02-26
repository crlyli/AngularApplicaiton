using AngularAspCore.Database;
using AngularAspCore.Database.Data.Models;
using AngularAspCore.Database.Data.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace AngularAspCore.Server.Controllers
{
    /// <summary>
    /// Reading Log Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ReadingLogController : Controller
    {
        private readonly IRepositoryWraper _repo;
        
        /// <summary>
        /// Reading log controller constructor
        /// </summary>
        public ReadingLogController(IRepositoryWraper repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Add Reading log
        /// </summary>
        /// <param name="modeldata">Reading log model data to add</param>
        [HttpPost]
        public async Task<IActionResult> AddReadingLogAsync([FromBody] ReadingLogDto modeldata)
        {
            int? logId = null;
            try
                {
                
                    if (modeldata is null)
                        return BadRequest("Reading Log object is null");
                    else
                    {
                        var model = DataConverters.ConvertToReadingLogDataModel(modeldata);
                        logId = await _repo.ReadingLogRepository.Add(model);
                    }
                        
                }
                catch (Exception ex)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        ex.Message);
                }
                return CreatedAtAction(nameof(GetReadingLog), new { id = logId }, modeldata);

        }

        /// <summary>
        /// Get Reading log list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetReadingLogAsync()
        {
            try
            {
                var books = _repo.ReadingLogRepository.GetAllData();
                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message);
            }
        }
        //=> _repo.ReadingLogRepository.GetAllData();

        /// <summary>
        /// Get Reading log by id
        /// </summary>
        /// <param name="id">Unique reading log id</param>
        /// <returns>Reading log or bad result</returns>
        [HttpGet("{id:int}")]
        public ActionResult GetReadingLog(int id)
        {
            try
            {
                var result = _repo.ReaderRepository.GetById(id);

                if (result is null)
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
        /// Delete reading log with id pk
        /// </summary>
        /// <param name="id">Reading log id</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReadingLogAsync(int id)
        {
            try
            {
                await _repo.ReadingLogRepository.DeleteById(id);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message + "Error deleting data");
            }
            return Ok();
        }

        /// <summary>
        /// Update Reading Log TODO
        /// </summary>
        /// <param name="modeldata"></param>
        /// <returns></returns>
        [HttpPatch]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateReadingLog([FromBody] ReadingLogDataModel modeldata)
        {
            try
            {
                await _repo.ReadingLogRepository.Update(modeldata);    
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
