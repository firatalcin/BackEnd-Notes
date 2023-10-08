using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
        where T : class
    {

        protected readonly RepositoryContext _context;

        public RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);   
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return trackChanges ? 
                _context.Set<T>() :
                _context.Set<T>().AsNoTracking();   
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> filter, bool trackChanges)
        {
            return trackChanges ? 
                _context.Set<T>().Where(filter) :
                _context.Set<T>().Where(filter).AsNoTracking();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
