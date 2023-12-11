using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        #region fields
        ISubjectRepo Subject { get; }
        #endregion

        #region functions
        IDbContextTransaction BeginTransaction();
        void Commit();
        void RollBack();

        Task<int> SaveChangesAsync();
        #endregion
    }
}
