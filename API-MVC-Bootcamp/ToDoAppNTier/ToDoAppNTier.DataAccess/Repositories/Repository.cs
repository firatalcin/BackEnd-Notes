using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDoAppNTier.DataAccess.Contexts;
using ToDoAppNTier.DataAccess.Interfaces;

namespace ToDoAppNTier.DataAccess.Repositories
{
    internal class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly ToDoContext _toDoContext;

        public Repository(ToDoContext toDoContext)
        {
            _toDoContext = toDoContext;
        }

        public async Task Create(T entity)
        {
            await _toDoContext.Set<T>().AddAsync(entity);
        }

        public Task<List<T>> GetAll()
        {
            return _toDoContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByFilter(Expression<Func<T, bool>> filter, bool asNoTracking = false)
        {
            return asNoTracking ?
                await _toDoContext.Set<T>().SingleOrDefaultAsync(filter) :
                await _toDoContext.Set<T>().AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task<T> GetById(object id)
        {
            return await _toDoContext.Set<T>().FindAsync(id);
        }

        public void Remove(T entity)
        { 
            _toDoContext.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _toDoContext.Set<T>().Update(entity);
        }
    }
}
