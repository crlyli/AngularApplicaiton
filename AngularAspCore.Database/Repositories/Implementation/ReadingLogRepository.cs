using AngularAspCore.Database.Data.Models;
using AngularAspCore.Database.Repositories.DbContextData;
using AngularAspCore.Database.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq;



namespace AngularAspCore.Database.Repositories.Implementation
{
    public class ReadingLogRepository : BaseRepository<ReadingLogDataModel>, IReadingLogRepository
    {
        private readonly ApplicationDbContext _mDbContext;

        /// <summary>
        /// Reading log repository constructor
        /// </summary>
        /// <param name="repositoryContext">db context</param>
        public ReadingLogRepository(ApplicationDbContext repositoryContext) : base(repositoryContext) 
        {
            _mDbContext = repositoryContext;
        }

        ///<inheritdoc/>
        public IEnumerable<ReadingLogDataModel> GetAllData()
        {
            return _mDbContext.ReadingLog.Include(s => s.Reader)
                .Include(s =>s.Book)
                .AsEnumerable();
        }

        ///<inheritdoc cref="IBaseRepository{T}"/> 
        public async Task<ReadingLogDataModel> Add(ReadingLogDataModel readinglog)
        {
            await _dbContext.ReadingLog.AddAsync(readinglog);
            await _dbContext.SaveChangesAsync();
            return readinglog;
        }
    }
}