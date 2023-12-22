using ExamMaster.Application.Contracts.IServices;
using ExamMaster.Application.Contracts.Repos;
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
        public IExamRepo Exam { get; private set; }
        public ISubjectLevelRepo SubjectLevel { get; private set; }
        public IQuestionsRepo Question { get; private set; }
        public IChoiceRepo Chioce { get; private set; }
        public IStudentExamRepo StudentExam { get; private set; }
        private readonly ApplicationDbContext _context;
        #endregion

        #region constructors
        public UnitOfWork(ApplicationDbContext context, ICacheService cacheService)
        {
            _context = context;
            Subject = new SubjectRepo(_context);
            Level = new LevelRepo(_context);
            SubjectLevel = new SubjectLevelRepo(_context);
            Exam = new ExamRepo(_context, cacheService);
            Question = new QuestionRepo(_context,cacheService);
            Chioce = new ChoiceRepo(_context);
            StudentExam = new StudentExamRepo(_context);
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
