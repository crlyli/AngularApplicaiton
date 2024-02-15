using AngularAspCore.Database.Data.Models;

namespace AngularAspCore.Database.Repositories.Interface
{
    /// <summary>
    /// Reader Repository Implementation
    /// </summary>
    public interface IReaderRepository : IBaseRepository<ReaderDataModel>
    {
        /// <summary>
        /// Delete Reader by Id
        /// </summary>
        /// <param name="id">Reader Id pk</param>
        void DeleteById(int id);
    }
}
