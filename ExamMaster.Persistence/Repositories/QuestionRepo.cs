using ExamMaster.Application.Common.Enums.Constents;
using ExamMaster.Application.Contracts.IServices;
using ExamMaster.Application.Contracts.Repos;
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
    public class QuestionRepo : BaseRepo<Question>, IQuestionsRepo
    {
        #region fields
        private readonly ApplicationDbContext _context;
        private readonly ICacheService _cacheService;
        #endregion


        #region constructor
        public QuestionRepo(ApplicationDbContext context, ICacheService cacheService) : base(context)
        {
            _context = context;
            _cacheService = cacheService;
        }
        #endregion


        #region actions

        public override Task<Question> AddAsync(Question entity)
        {
            ClearQuestionFormCacheMemory();
            return base.AddAsync(entity);
        }
        public override Question Update(Question entity)
        {
            ClearQuestionFormCacheMemory();
            return base.Update(entity);
        }
        public override void Delete(Question entity)
        {
            ClearQuestionFormCacheMemory();
            base.Delete(entity);
        }
        public IQueryable<Question> GetQueryable(int examId)
        {
            return _context.Questions.Where(x => x.ExamId == examId)
                                           .Include(x => x.Exam)
                                           .Include(x => x.QuestionType)
                                           .AsQueryable();
        }

        public async Task<Question> GetMultiChoiceById(int questionId)
        {
            return await _context.Questions.Where(x => x.Id == questionId)
                                           .Include(x => x.Choices)
                                           .SingleOrDefaultAsync();
        }
        public void ClearQuestionFormCacheMemory()
        {
            _cacheService.Remove($"{nameof(CachedKey.QuestionsExam)}");
            _cacheService.Remove($"{nameof(CachedKey.ExamQuestionAnswer)}");
        }
        #endregion


    }
}
