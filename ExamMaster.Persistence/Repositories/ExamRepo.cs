using ExamMaster.Application.Common.Enums.Constents;
using ExamMaster.Application.Contracts.IServices;
using ExamMaster.Application.Contracts.Repos;
using ExamMaster.Application.Features.Exams.Queries.Models.Responses;
using ExamMaster.Application.Features.Questions.MultiChoice.Commands.Models.ViewModel;
using ExamMaster.Application.Features.Questions.MultiChoice.Queries.Models.Response;
using ExamMaster.Domain.Entities;
using ExamMaster.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Persistence.Repositories
{
    public class ExamRepo : BaseRepo<Exam>, IExamRepo
    {
        private ApplicationDbContext _context;
        private readonly ICacheService _cacheService;

        public ExamRepo(ApplicationDbContext context, ICacheService cacheService) : base(context)
        {
            _context = context;
            _cacheService = cacheService;
        }
        public async Task<IEnumerable<Exam>> GetAsync(int subjectId)
        {
            return await _context.Exam.Where(x => x.SubjectId == subjectId)
                                       .Include(x => x.Level)
                                       .Include(x => x.Subject)
                                       .ToListAsync();
        }
        public async Task<IEnumerable<Exam>> GetAsync(int subjectId, int? levelId)
        {
            return await _context.Exam.Where(x => x.SubjectId == subjectId && x.LevelId == levelId)
                                      .Include(x => x.Level)
                                      .Include(x => x.Subject)
                                      .ToListAsync();
        }
        public override async Task<Exam> GetByIdAsync(int id)
        {
            return await _context.Exam.Where(x => x.Id == id)
                                      .Include(x => x.Level)
                                      .Include(x => x.Subject)
                                      .SingleOrDefaultAsync();
        }


        public async Task<IEnumerable<ExamQuestionGroupResponse>> GetQuestions(int examId, string key)
        {
            var result = await _cacheService.Get<IEnumerable<ExamQuestionGroupResponse>>(key);
            if (result is null)
            {
                var groupedQuestions = _context.Exam.Where(x => x.Id == examId)
                    .SelectMany(x => x.Questions)
                    .Include(x => x.Choices)
                    .GroupBy(x => x.QuestionTypeId)
                    .Select(e => new ExamQuestionGroupResponse
                    {
                        QuestionTypeName = e.Key.ToString(),
                        Questions = e.ToList()
                    });

                result = await groupedQuestions.ToListAsync();
                _cacheService.Set(key, result);
            }
            return result;
        }

        public async Task<IEnumerable<QuestionsChoiceCorrectAnswer>> GetMultiChoiceAnswer(int examId, string Key)
        {
            var result = await _cacheService.Get<IEnumerable<QuestionsChoiceCorrectAnswer>>(Key);
            if (result is null)
            {
                var QueriableAnswer = from exam in _context.Exam
                        join questions in _context.Questions
                        on exam.Id equals questions.ExamId
                        where exam.Id == examId

                        join choice in _context.Choice
                        on questions.Id equals choice.QuestionId
                        where choice.IsCorrect == true

                        select new QuestionsChoiceCorrectAnswer
                        {
                            QuestionId = questions.Id,
                            AnswerId = choice.Id,
                            QuestionPoint = questions.Point
                        };

                result = await QueriableAnswer.ToListAsync();
            }

            return result;
        }


    }
}
