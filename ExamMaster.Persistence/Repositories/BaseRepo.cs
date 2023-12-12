using ExamMaster.Application.Contracts;
using ExamMaster.Persistence.Context;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Persistence.Repositories
{
    public class BaseRepo<T> : IBaseRepo<T> where T : class
    {
        #region fileds

        protected readonly ApplicationDbContext _context;

        #endregion



        #region Constructor(s)
        public BaseRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion




        #region Actions


        public virtual async Task<T> GetByIdAsync(int id)
        {

            return await _context.Set<T>().FindAsync(id);
        }
        public virtual async Task<IEnumerable< T>> GetAllAsync()
        {

            return await _context.Set<T>().ToListAsync();
        }
        public virtual async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);


            return entity;
        }

        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return entity;

        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }


        public IQueryable<T> GetTableNoTracking()
        {
            return _context.Set<T>().AsNoTracking().AsQueryable();
        }

        public IQueryable<T> GetTableAsTracking()
        {
            return _context.Set<T>().AsQueryable();

        }


        public async Task<bool> IsExistAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().AnyAsync(expression);
        }


        public virtual async Task<ICollection<T>> AddRangeAsync(ICollection<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            return entities;
        }


        public void UpdateRange(ICollection<T> entities)
        {
            _context.Set<T>().UpdateRange(entities);
        }


        public void DeleteRange(ICollection<T> entities)
        {
            foreach (var entity in entities)
            {
                _context.Entry(entity).State = EntityState.Deleted;
            }
        }

   

        #endregion
    }

}
