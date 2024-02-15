using AngularAspCore.Database.Repositories.DbContextData;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
namespace AngularAspCore.Database.Repositories
{
    ///<inheritdoc cref="IBaseRepository{T}"/> 
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ApplicationDbContext RepositoryContent { get; set; }
        protected BaseRepository(ApplicationDbContext repositoryContent)
        {
            RepositoryContent = repositoryContent;
        }

        ///<inheritdoc cref="IBaseRepository{T}"/> 
        public IEnumerable<T> GetAll()
        {
            return RepositoryContent.Set<T>().AsEnumerable();
        }

        ///<inheritdoc cref="IBaseRepository{T}"/> 
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return RepositoryContent.Set<T>()
                .Where(expression).AsNoTracking();
        }

        ///<inheritdoc cref="IBaseRepository{T}"/> 
        public void Add(T entity)
        {
            RepositoryContent.Set<T>().Add(entity);
        }

        ///<inheritdoc cref="IBaseRepository{T}"/> 
        public void Update(T entity)
        {
            RepositoryContent.Set<T>().Update(entity);
        }

        ///<inheritdoc cref="IBaseRepository{T}"/> 
        public void Delete(T entity)
        {
            RepositoryContent.Set<T>().Remove(entity);
        }
    }

}
