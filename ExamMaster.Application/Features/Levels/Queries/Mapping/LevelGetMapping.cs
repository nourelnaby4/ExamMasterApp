using AutoMapper;
using ExamMaster.Application.Features.Levels.Command.Model.Requests;
using ExamMaster.Application.Features.Levels.Queries.Models.Response;
using ExamMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Levels.Queries.Mapping
{
    public class LevelGetMapping :Profile
    {
        #region constructor
        public LevelGetMapping()
        {
            GetLevel();

        }
        #endregion

        #region mapping function
        public void GetLevel()
        {
            CreateMap<Level, LevelGetResponse>();
        }
        #endregion
    }
}
