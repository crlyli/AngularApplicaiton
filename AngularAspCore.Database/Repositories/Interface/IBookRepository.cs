using AngularAspCore.Database.Data.Models;
using AngularAspCore.Database.Data.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace AngularAspCore.Database.Repositories.Interface
{
    /// <summary>
    /// Book Repository Interface
    /// </summary>
    public interface IBookRepository : IBaseRepository<BookDataModel>
    {
        /// <summary>
        /// Delete Book by Id
        /// </summary>
        /// <param name="id">Book Id pk</param>
        Task DeleteById(int id);
    }
}
