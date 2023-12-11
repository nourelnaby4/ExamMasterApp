using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Contracts
{
    public interface IBaseRepo<T> where T : class
    {
        Task<T> GetByIdAsync(int id);

        Task<T> AddAsync(T entity);
        T Update(T entity);
        void Delete(T entity);

        Task<bool> IsExistAsync(Expression<Func<T, bool>> expression);

        IQueryable<T> GetTableNoTracking();
        IQueryable<T> GetTableAsTracking();

        Task<ICollection<T>> AddRangeAsync(ICollection<T> entities);
        void DeleteRange(ICollection<T> entities);
        void UpdateRange(ICollection<T> entities);
    }
}
