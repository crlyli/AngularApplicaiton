using AngularAspCore.Database.Data.Models;
using AngularAspCore.Database.Repositories.DbContextData;
using AngularAspCore.Database.Repositories.Interface;

namespace AngularAspCore.Database.Repositories.Implementation
{
    /// <summary>
    /// Book Repository 
    /// </summary>
    public class BookRepository : BaseRepository<BookDataModel>, IBookRepository
    {
        private readonly ApplicationDbContext
            _mDbContext;

        /// <summary>
        /// Book Repository Constructor
        /// </summary>
        /// <param name="dbContext"></param>
        public BookRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            _mDbContext = dbContext;
        }

        ///<inheritdoc cref="IBookRepository"/>
        public void DeleteById(int id)
        {
            var fBook = _mDbContext.BookData.Where(book => book.Id == id).FirstOrDefault();
            _mDbContext.Remove(fBook);
            _mDbContext.SaveChangesAsync();
        }
    }
}
