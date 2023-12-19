using ExamMaster.Application.Features.Exams.Queries.Models.Responses;
using ExamMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Contracts
{
    public interface IQuestionsRepo : IBaseRepo<Question>
    {
        IQueryable<Question> GetQueryable(int examId);
        Task<Question> GetMultiChoiceById(int questionId);
    }
}
