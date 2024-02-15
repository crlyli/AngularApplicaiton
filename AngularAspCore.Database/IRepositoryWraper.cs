using AngularAspCore.Database.Repositories.Interface;

namespace AngularAspCore.Database
{
    public interface IRepositoryWraper
    {
        IBookRepository BookRepository { get; }
        IReaderRepository ReaderRepository { get; }
        IReadingLogRepository ReadingLogRepository { get; }
        Task SaveAsync();
    }
}
