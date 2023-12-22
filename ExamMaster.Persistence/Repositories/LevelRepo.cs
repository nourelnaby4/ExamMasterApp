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
    public class LevelRepo : BaseRepo<Level>, ILevelRepo
    {
        public LevelRepo(ApplicationDbContext context) : base(context)
        {
        }
    }
}
