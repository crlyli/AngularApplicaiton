using AngularAspCore.Database.Data.Models;

namespace AngularAspCore.Database.Repositories.Interface
{
    /// <summary>
    /// Reading Log Repository Interface
    /// </summary>
    public interface IReadingLogRepository : IBaseRepository<ReadingLogDataModel>
    {
        /// <summary>
        /// Enumberable list of Reading Log Data
        /// </summary>
        /// <returns>Returns reading log data</returns>
        IEnumerable<ReadingLogDataModel> GetAllData();

        Task<int> Add(ReadingLogDataModel readinglog);
    }
}
