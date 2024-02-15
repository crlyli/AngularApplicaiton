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
            try
            {
                var model = DataConverters.ConvertToReadingLogDataModel(modeldata);
                if (modeldata is null)
                    return BadRequest("Owner object is null");
                else
                    _repo.ReadingLogRepository.Add(model);
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
        /// Get Reading log list
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ReadingLogDataModel> GetReadingLogAsync() => _repo.ReadingLogRepository.GetAllData();

        /// <summary>
        /// Delete reading log with id pk
        /// </summary>
        /// <param name="id">Reading log id</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReadingLogAsync(int id)
        {
            try
            {
                _repo.ReadingLogRepository.DeleteById(id);
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
                _repo.ReadingLogRepository.Update(modeldata);
                await _repo.SaveAsync();

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
