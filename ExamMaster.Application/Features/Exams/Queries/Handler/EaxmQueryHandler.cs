using AutoMapper;
using AVMS.Application.Common.Model;
using ExamMaster.Application.Common.Enums.Constents;
using ExamMaster.Application.Contracts.Repos;
using ExamMaster.Application.Features.Exams.Queries.Models.Requests;
using ExamMaster.Application.Features.Exams.Queries.Models.Responses;
using ExamMaster.Application.Features.Questions.MultiChoice.Commands.Models.ViewModel;
using ExamMaster.Application.Features.Questions.MultiChoice.Queries.Models.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Exams.Queries.Handler
{
    public class EaxmQueryHandler : ResponseHandler,
                                     IRequestHandler<ExamGetAllRequest, Response<IEnumerable<ExamGetAllResponse>>>,
                                     IRequestHandler<ExamGetByIdRequest, Response<ExamGetAllResponse>>,
                                     IRequestHandler<ExamQuestionGroupingRequest, Response<IEnumerable<ExamQuestionGroupResponse>>>

    {

        #region fields
        private readonly IUnitOfWork _repo;
        private readonly IMapper _mapper;
        #endregion


        #region constructors
        public EaxmQueryHandler(IUnitOfWork repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        #endregion

        #region actions

        public async Task<Response<IEnumerable<ExamGetAllResponse>>> Handle(ExamGetAllRequest request, CancellationToken cancellationToken)
        {
            var exams =  await _repo.Exam.GetAsync(request.SubjectId,request.LevelId);
            var mapping = _mapper.Map<IEnumerable<ExamGetAllResponse>>(exams);
            return Success(mapping);
        }

        public async Task<Response<ExamGetAllResponse>> Handle(ExamGetByIdRequest request, CancellationToken cancellationToken)
        {
            var exams = await _repo.Exam.GetByIdAsync(request.Id);
            if (exams == null)
            {
                return NotFound<ExamGetAllResponse>("Exam not found");
            }
            var mapping = _mapper.Map<ExamGetAllResponse>(exams);
            return Success(mapping);
        }

        public async Task<Response<IEnumerable<ExamQuestionGroupResponse>>> Handle(ExamQuestionGroupingRequest request, CancellationToken cancellationToken)
        {
            var ExamQuestions = await _repo.Exam.GetQuestions(request.ExamId);
            return Success(ExamQuestions);
        }

        #endregion


    }
}