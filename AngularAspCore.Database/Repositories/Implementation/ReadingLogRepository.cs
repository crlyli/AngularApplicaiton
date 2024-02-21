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
        public async Task DeleteById(int id)
        {
            var fReadingLog = _mDbContext.Reader.Where(log => log.Id == id).FirstOrDefault();
            if (fReadingLog is not null)
            {
                _mDbContext.Remove(fReadingLog);
                await _mDbContext.SaveChangesAsync();
            }
        }

        ///<inheritdoc/>
        public IEnumerable<ReadingLogDataModel> GetAllData()
        {
            return _mDbContext.ReadingLog.Include(s => s.Reader)
                .Include(s =>s.Book)
                .AsEnumerable();
        }
    }
}