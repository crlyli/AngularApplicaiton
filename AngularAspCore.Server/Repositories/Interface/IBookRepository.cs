using AngularAspCore.Server.Data.Models.Domain;

namespace AngularAspCore.Server.Repositories.Interface
{
    public interface IBookRepository
    {
        Task<BookData> CreateAsync(BookData bookData);
    }
}
