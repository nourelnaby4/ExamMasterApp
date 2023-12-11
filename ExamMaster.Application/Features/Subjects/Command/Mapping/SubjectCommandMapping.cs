using AutoMapper;
using ExamMaster.Application.Features.Subjects.Command.Model;
using ExamMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Subjects.Command.Mapping
{
    public class SubjectCommandMapping : Profile
    {
        #region constructor
        public SubjectCommandMapping()
        {
            CreateSubject();
        
        }
        #endregion

        #region mapping function
        public void CreateSubject()
        {
            CreateMap<SubjectCreateRequest, Subject>();
        }
        #endregion
    }
}
