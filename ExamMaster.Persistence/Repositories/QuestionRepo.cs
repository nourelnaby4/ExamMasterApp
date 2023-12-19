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
        public override Task<Question> AddAsync(Question entity)
        {
           throw new NotImplementedException();
        }
        public override Question Update(Question entity)
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

     


       
        
        #endregion


    }
}
