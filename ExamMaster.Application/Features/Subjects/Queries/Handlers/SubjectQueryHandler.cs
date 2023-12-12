using AutoMapper;
using AVMS.Application.Common.Model;
using ExamMaster.Application.Contracts;
using ExamMaster.Application.Features.Subjects.Command.Model.Requests;
using ExamMaster.Application.Features.Subjects.Queries.Models.Requests;
using ExamMaster.Application.Features.Subjects.Queries.Models.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Subjects.Queries.Handlers
{
    public class SubjectQueryHandler : ResponseHandler,
                                       IRequestHandler<SubjectGetAllRequest, Response<IEnumerable<SubjectGetResponse>>>,
                                       IRequestHandler<SubjectGetByIdRequest, Response<SubjectGetResponse>>
         

    {

        #region fields
        private readonly IUnitOfWork _repo;
        private readonly IMapper _mapper;

        #endregion

        #region constracturs
        public SubjectQueryHandler(IUnitOfWork repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<Response<SubjectGetResponse>> Handle(SubjectGetByIdRequest request, CancellationToken cancellationToken)
        {
            var subject = await _repo.Subject.GetByIdAsync(request.Id);
            if (subject is null)
                return BadRequest<SubjectGetResponse>("subject is not found");

            var response= _mapper.Map<SubjectGetResponse>(subject);
            return Success( response);
        }

        public async Task<Response<IEnumerable<SubjectGetResponse>>> Handle(SubjectGetAllRequest request, CancellationToken cancellationToken)
        {
            var subject = await _repo.Subject.GetAllAsync();
            

            var response = _mapper.Map<IEnumerable< SubjectGetResponse>>(subject);
            return Success(response);
        }
        #endregion

        #region handlers

        #endregion
    }
}
