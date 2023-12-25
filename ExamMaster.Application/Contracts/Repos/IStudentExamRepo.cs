using ExamMaster.Application.Common.Model;
using ExamMaster.Application.Features.Exams.Queries.Models.Responses;
using ExamMaster.Application.Features.Questions.MultiChoice.Queries.Models.Response;
using ExamMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Contracts.Repos
{
    public interface IStudentExamRepo : IBaseRepo<StudentExam>
    {
        Task<PaginatedResult<StudentExamMarkGetRespose>> GetPaginated(Expression<Func<StudentExamMarkGetRespose, bool>> predicate, int pageNumber, int pageSize);
        Task<PaginatedResult<StudentExamMarkGetRespose>> GetPaginated( int pageNumber, int pageSize);
    }
}
