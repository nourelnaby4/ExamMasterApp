using ExamMaster.Application.Contracts;
using ExamMaster.Domain.Entities;
using ExamMaster.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Persistence.Repositories
{
    public class ExamRepo : BaseRepo<Exam> ,IExamRepo
    {
        public ExamRepo(ApplicationDbContext context) : base(context)
        {

        }

    }
}
