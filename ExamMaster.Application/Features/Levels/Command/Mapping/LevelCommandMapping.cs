using AutoMapper;
using ExamMaster.Application.Features.Levels.Command.Model.Requests;
using ExamMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Levels.Command.Mapping
{
    public class LevelCommandMapping : Profile
    {
        #region constructor
        public LevelCommandMapping()
        {
            CreateLevel();
            EditLevel();
        
        }
        #endregion

        #region mapping function
        public void CreateLevel()
        {
            CreateMap<LevelCreateRequest, Level>();
        }

        public void EditLevel()
        {
            CreateMap<LevelEditRequest, Level>();
        }
        #endregion
    }
}
