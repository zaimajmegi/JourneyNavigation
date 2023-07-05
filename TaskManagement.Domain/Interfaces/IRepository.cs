using System.Linq.Expressions;

namespace TaskManagement.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveWithChildren(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        int Count();

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        TEntity GetSingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        TEntity Get(int id);

        IEnumerable<TEntity> GetAll();

        IQueryable<TEntity> GetAllQueryable();

        Task<TEntity> GetAsync(int id);
        Task<TEntity> GetAsync(string id);

        Task<IEnumerable<TEntity>> GetAllAsync();
       
    }
}
