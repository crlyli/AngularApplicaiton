using AngularAspCore.Database.Data.Models;

namespace AngularAspCore.Database.Repositories.Interface
{
    /// <summary>
    /// Reading Log Repository Interface
    /// </summary>
    public interface IReadingLogRepository : IBaseRepository<ReadingLogDataModel>
    {
        /// <summary>
        /// Delete Reading Lob by id
        /// </summary>
        /// <param name="id">Reading Log Id</param>
        void DeleteById(int id);

        /// <summary>
        /// Enumberable list of Reading Log Data
        /// </summary>
        /// <returns>Returns reading log data</returns>
        IEnumerable<ReadingLogDataModel> GetAllData();
    }
}
