using ExamMaster.Application.Features.Exams.Queries.Models.Responses;
using ExamMaster.Application.Features.Questions.MultiChoice.Commands.Models.ViewModel;
using ExamMaster.Application.Features.Questions.MultiChoice.Queries.Models.Response;
using ExamMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Contracts.Repos
{
    public interface IExamRepo : IBaseRepo<Exam>
    {
        Task<IEnumerable<Exam>> GetAsync(int subjectId);
        Task<IEnumerable<Exam>> GetAsync(int subjectId, int? levelId);
        Task<IEnumerable<ExamQuestionGroupResponse>> GetQuestions(int examId, string key);
        Task<IEnumerable<QuestionsChoiceCorrectAnswer>> GetMultiChoiceAnswer(int examId, string Key);
    }
}
