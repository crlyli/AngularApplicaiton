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
        //Task DeleteById(int id);

        /// <summary>
        /// Get Reader by id
        /// </summary>
        /// <param name="id">unique key id</param>
        /// <returns>The Reader Data model associated with id</returns>
        //ReaderDataModel GetById(int id);
    }
}
