using ExamMaster.Application.Contracts;
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
        public ExamRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable< Exam>> GetALL()
        {
           return  await _context.Exam. Include(x => x.Level).Include(x=> x.Subject).ToListAsync();
        }
        public override async Task<Exam> GetByIdAsync(int id)
        {
            return await _context.Exam.Where(x => x.Id == id)
                                      .Include(x => x.Level)
                                      .Include(x => x.Subject)
                                      .SingleOrDefaultAsync();
        }
    }
}
