using AngularAspCore.Database.Data.Models;
using AngularAspCore.Database.Repositories.DbContextData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;
using System.Linq.Expressions;
namespace AngularAspCore.Database.Repositories
{
    ///<inheritdoc cref="IBaseRepository{T}"/> 
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ApplicationDbContext _dbContext { get; set; }
        protected BaseRepository(ApplicationDbContext repositoryContent)
        {
            _dbContext = repositoryContent;
        }

        ///<inheritdoc cref="IBaseRepository{T}"/> 
        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().AsEnumerable();
        }

        ///<inheritdoc cref="IBaseRepository{T}"/> 
        public async Task Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        ///<inheritdoc cref="IBaseRepository{T}"/> 
        public async Task Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        ///<inheritdoc cref="IBaseRepository{T}"/> 
        public async Task Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<T> DeleteById(int id)
        {
            var fResults = _dbContext.Set<T>().Find(id);
            if (fResults is not null)
            {
                _dbContext.Remove(fResults);
                await _dbContext.SaveChangesAsync();
                
            }
            return fResults;
        }
        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }
    }

}
