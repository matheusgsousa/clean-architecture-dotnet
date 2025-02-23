using System.Linq.Expressions;

namespace clean_arch.Persistence.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T?> GetById(Guid id);
        Task<T> Insert(T entity);
        void Create(T entity);

        void CreateMany(IEnumerable<T> entity);

        void Delete(T entity);

        void Update(T entity);

        IQueryable<T> GetAll();

        IQueryable<T> GetByExpression(Expression<Func<T, bool>> filter);
    }
}
