using ExamMaster.Application.Common.Enums.Constents;
using ExamMaster.Application.Common.Extentions;
using ExamMaster.Application.Common.Model;
using ExamMaster.Application.Contracts.IServices;
using ExamMaster.Application.Contracts.Repos;
using ExamMaster.Application.Features.Exams.Queries.Models.Responses;
using ExamMaster.Application.Features.Questions.MultiChoice.Queries.Models.Response;
using ExamMaster.Domain.Entities;
using ExamMaster.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Persistence.Repositories
{
    public class StudentExamRepo : BaseRepo<StudentExam>, IStudentExamRepo
    {
        #region fields
        private readonly ApplicationDbContext _context;

        #endregion

        #region constructors
        public StudentExamRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }



        #endregion

        #region actions
   

        public async Task<PaginatedResult<StudentExamMarkGetRespose>> GetPaginated(Expression<Func<StudentExamMarkGetRespose, bool>> predicate, int pageNumber, int pageSize)
        {
            var QueryableModel = GetQuerableStudentMark();
            return await QueryableModel.Where(predicate).ToPaginatedListAsync(pageNumber,pageSize);
        }
        public async Task<PaginatedResult<StudentExamMarkGetRespose>> GetPaginated( int pageNumber, int pageSize)
        {
            var QueryableModel = GetQuerableStudentMark();
            return await QueryableModel.ToPaginatedListAsync(pageNumber, pageSize);
        }

        private IQueryable<StudentExamMarkGetRespose> GetQuerableStudentMark()
        {
            var QueryableModel = from student in _context.ApplicationUsers
                                 join studentExam in _context.StudentExams
                                 on student.Id equals studentExam.StudentId
                                 join exam in _context.Exam
                                 on studentExam.ExamId equals exam.Id


                                 select new StudentExamMarkGetRespose
                                 {
                                     StudentName = student.UserName,
                                     SubjectName = exam.Subject.Name,
                                     LevelName = exam.Level.Name,
                                     ExamTitle = exam.Title,
                                     TotalScore = studentExam.Score,
                                     ScoreRate = studentExam.ScoreRate,
                                     IsSuccess = studentExam.IsSuccess,
                                 };
            return QueryableModel;
        }
        #endregion
    }
}
