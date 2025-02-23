using clean_arch.Domain.Entities.Base;
using clean_arch.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace clean_arch.Persistence.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly MySqlDatabaseContext _context;
        private DbSet<T> _objectset = null!;

        public BaseRepository(MySqlDatabaseContext context)
        {
            _context = context;
            _context.ChangeTracker.LazyLoadingEnabled = false;
        }

        protected DbSet<T> ObjectSet
        {
            get
            {
                _objectset ??= _context.Set<T>();
                return _objectset;
            }
        }

        public Task<T?> GetById(Guid id) => ObjectSet.FirstOrDefaultAsync(x => x.Id == id);
        public async Task<T> Insert(T entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            await ObjectSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual void Create(T entity)
        {
            ArgumentNullException.ThrowIfNull(entity);

            ObjectSet.Add(entity);
        }

        public virtual void CreateMany(IEnumerable<T> entities)
        {
            ArgumentNullException.ThrowIfNull(entities);

            ObjectSet.AddRange(entities);
        }

        public virtual void Delete(T entity)
        {
            ObjectSet.Remove(entity);
        }

        public virtual IQueryable<T> GetAll()
        {
            return ObjectSet.AsQueryable();
        }

        public virtual void Update(T entity)
        {
            ObjectSet.Update(entity);
        }

        public IQueryable<T> GetByExpression(Expression<Func<T, bool>> filter)
        {
            return ObjectSet.Where(filter);
        }
    }
}
