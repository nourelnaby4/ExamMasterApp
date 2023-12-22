using ExamMaster.Application.Contracts.Repos;
using ExamMaster.Domain.Entities;
using ExamMaster.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Persistence.Repositories
{
    public class StudentExamRepo : BaseRepo<StudentExam>, IStudentExamRepo
    {
        #region constructors
        public StudentExamRepo(ApplicationDbContext context) : base(context)
        {
        }

        #endregion
    }
}
