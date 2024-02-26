using AngularAspCore.Database.Data.Models;
using AngularAspCore.Database.Repositories.DbContextData;
using AngularAspCore.Database.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularAspCore.Database.Repositories.Implementation
{
    /// <summary>
    /// Reader Repository
    /// </summary>
    public class ReaderRepository : BaseRepository<ReaderDataModel>, IReaderRepository
    {
        private readonly ApplicationDbContext
            _mDbContext;

        /// <summary>
        /// Reader Repository Constructor
        /// </summary>
        public ReaderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _mDbContext = dbContext;
        }

        /////<inheritdoc cref="IReaderRepository"/>
        //public async Task DeleteById(int id)
        //{
        //    var fReader = _mDbContext.Reader.Where(reader => reader.Id == id).FirstOrDefault();
        //    if (fReader is not null)
        //    {
        //        _mDbContext.Remove(fReader);
        //        await _mDbContext.SaveChangesAsync();
        //    }
        //}
    }
}
