using ExamMaster.Application.Contracts;
using ExamMaster.Application.Features.Exams.Queries.Models.Responses;
using ExamMaster.Domain.Entities;
using ExamMaster.Persistence.Context;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IEnumerable< Exam>> GetAsync(int subjectId)
        {
           return  await _context.Exam.Where(x=>x.SubjectId==subjectId)
                                      .Include(x => x.Level)
                                      .Include(x=> x.Subject)
                                      .ToListAsync();
        }
        public async Task<IEnumerable<Exam>> GetAsync(int subjectId,int? levelId)
        {
            return await _context.Exam.Where(x => x.SubjectId == subjectId && x.LevelId==levelId)
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


            var groupedQuestions = _context.Exam
        .Where(x => x.Id == 5)
        .SelectMany(x => x.Questions)
        .Include(x => x.QuestionType)
        .Include(x => x.Choices)
        .GroupBy(x => x.QuestionType.TypeName)
        .Select(e => new ExamQuestionGroupResponse
        {
            QuestionTypeName = e.Key,
            Questions = e.ToList()
        });


            var result = await _cacheService.Get<IEnumerable<ExamQuestionGroupResponse>>(key);
            if (result is null)
            {
                result = await groupedQuestions.ToListAsync();
                _cacheService.Set(key, result);
            }

            return result;
        }

    }
}
