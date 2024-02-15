using AngularAspCore.Database.Repositories.DbContextData;
using AngularAspCore.Database.Repositories.Implementation;
using AngularAspCore.Database.Repositories.Interface;

namespace AngularAspCore.Database
{
    public class RepositoryWrapper : IRepositoryWraper
    {
        private IBookRepository _bookRepository;
        private IReaderRepository _readerRepository;
        private IReadingLogRepository   _readingLogRepository;
        private ApplicationDbContext _context;

        public IBookRepository BookRepository { get
            {
                if (_bookRepository == null)
                {
                    _bookRepository = new BookRepository(_context);
                }
                return _bookRepository;
            } 
        }

        public IReaderRepository ReaderRepository
        {
            get
            {
                if (_bookRepository == null)
                {
                    _readerRepository = new ReaderRepository(_context);
                }
                return _readerRepository;
            }
        }

        public IReadingLogRepository ReadingLogRepository
        {
            get
            {
                if (_bookRepository == null)
                {
                    _readingLogRepository = new ReadingLogRepository(_context);
                }
                return _readingLogRepository;
            }
        }

        public RepositoryWrapper(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
