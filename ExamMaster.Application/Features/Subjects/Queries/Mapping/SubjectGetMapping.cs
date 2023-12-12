using AutoMapper;
using ExamMaster.Application.Features.Subjects.Command.Model.Requests;
using ExamMaster.Application.Features.Subjects.Queries.Models.Response;
using ExamMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Subjects.Queries.Mapping
{
    public class SubjectGetMapping :Profile
    {
        #region constructor
        public SubjectGetMapping()
        {
            GetSubject();

        }
        #endregion

        #region mapping function
        public void GetSubject()
        {
            CreateMap<Subject, SubjectGetResponse>();
        }
        #endregion
    }
}
