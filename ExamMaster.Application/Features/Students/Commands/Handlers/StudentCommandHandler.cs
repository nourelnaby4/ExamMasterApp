using AutoMapper;
using AVMS.Application.Common.Model;
using ExamMaster.Application.Common.Enums.Constents;
using ExamMaster.Application.Contracts.Repos;
using ExamMaster.Application.Features.Exams.Commands.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler
    {

        #region fields
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _repo;
        #endregion

        #region constructor
        public StudentCommandHandler(IMapper mapper, IUnitOfWork repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        #endregion



        #region handlers
        #endregion
    }
}
