using AngularAspCore.Server.Data.Models.Domain;
using AngularAspCore.Server.Repositories.DbContextData;
using AngularAspCore.Server.Repositories.Interface;

namespace AngularAspCore.Server.Repositories.Implementation
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext
            _mDbContext;
        public BookRepository(ApplicationDbContext dbContext)
        {
           _mDbContext = dbContext;
        }
        public async Task<BookData> CreateAsync(BookData bookData)
        {
            await _mDbContext.AddAsync(bookData);
            await _mDbContext.SaveChangesAsync();
            return bookData;
        }
    }
}
