using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AngularAspCore.Database.Repositories
{
    /// <summary>
    /// Base Repository
    /// </summary>
    /// <typeparam name="T">Entity or Model</typeparam>
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// Get all Data
        /// </summary>
        /// <returns>All Data for for specified Entity</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Add To Entity
        /// </summary>
        /// <param name="entity">Entity to use</param>
        Task Add(T entity);

        /// <summary>
        /// Update Entity
        /// </summary>
        /// <param name="entity">Entity to update</param>
        Task Update(T entity);

        /// <summary>
        /// Delete Entity
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        Task Delete(T entity);
    }
}
