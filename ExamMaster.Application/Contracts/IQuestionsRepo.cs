using ExamMaster.Application.Features.Questions.MultiChoice.Queries.Models.Response;
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
        Task<IEnumerable<QuestionGroupResponse>> GetQuestions(string key, ICacheService cache);
    }
}
