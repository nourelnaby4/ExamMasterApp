using ExamMaster.Application.Contracts;
using ExamMaster.Application.Features.Questions.MultiChoice.Queries.Models.Response;
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
        #endregion


        #region constructor
        public QuestionRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        #endregion


        #region actions
        public  Task<Question> AddAsync(Question entity, ICacheService cache)
        {
           throw new NotImplementedException();
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

     


        public async Task<IEnumerable<QuestionGroupResponse>> GetQuestions( string key, ICacheService cache)
        {


            var groupedQuestions = _context.Exam
        .Where(x => x.Id == 5)
        .SelectMany(x => x.Questions)
        .Include(x => x.QuestionType)
        .Include(x => x.Choices)
        .GroupBy(x => x.QuestionType.TypeName)
        .Select(e => new QuestionGroupResponse
        {
            QuestionTypeName = e.Key,
            Questions = e.ToList()
        });


            //var result = await cache.Get<IEnumerable<QuestionGroupResponse>>(key);
            //if(result is null)
            //{
            //    result =await groupedQuestions.ToListAsync();
            //     cache.Set(key, result);
            //}
           
            //return result;
            return await groupedQuestions.ToListAsync();
        }
        #endregion


    }
}
