using ExamMaster.Application.Contracts;
using ExamMaster.Persistence.Context;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        #region fields
        public ISubjectRepo Subject { get; private set; }
        public ILevelRepo Level { get; private set; }
        private readonly ApplicationDbContext _context;
        #endregion

        #region constructors
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Subject = new SubjectRepo(_context);
            Level = new LevelRepo(_context);
        }
        #endregion


        #region functions
        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _context.Database.CommitTransaction();

        }

        public void RollBack()
        {
            _context.Database.RollbackTransaction();

        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        #endregion
    }
}
