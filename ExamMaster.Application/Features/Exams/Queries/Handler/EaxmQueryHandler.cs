using AutoMapper;
using AVMS.Application.Common.Model;
using ExamMaster.Application.Contracts;
using ExamMaster.Application.Features.Exams.Queries.Models.Requests;
using ExamMaster.Application.Features.Exams.Queries.Models.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Exams.Queries.Handler
{
    public class EaxmQueryHandler : ResponseHandler,
                                     IRequestHandler<ExamGetAllRequest, Response<IEnumerable<ExamGetResponse>>>,
                                     IRequestHandler<ExamGetByIdRequest, Response<ExamGetResponse>>
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

        public async Task<Response<IEnumerable<ExamGetResponse>>> Handle(ExamGetAllRequest request, CancellationToken cancellationToken)
        {
            var exams = await _repo.Exam.GetALL();
            var mapping = _mapper.Map<IEnumerable<ExamGetResponse>>(exams);

            return Success(mapping);
        }

        public async Task<Response<ExamGetResponse>> Handle(ExamGetByIdRequest request, CancellationToken cancellationToken)
        {
            var exams = await _repo.Exam.GetByIdAsync(request.Id);
            if (exams == null)
            {
                return NotFound<ExamGetResponse>("Exam not found");
            }
            var mapping = _mapper.Map<ExamGetResponse>(exams);
            return Success(mapping);
        }
        #endregion


    }
}
