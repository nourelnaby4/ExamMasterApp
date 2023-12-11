using AutoMapper;
using AVMS.Application.Common.Model;
using ExamMaster.Application.Contracts;
using ExamMaster.Application.Features.Subjects.Command.Model;
using ExamMaster.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Subjects.Command.Handler
{
    public class SubjectCommandHandler : ResponseHandler,
                                        IRequestHandler<SubjectCreateRequest, Response<string>>
    {

        #region fields
        private readonly IUnitOfWork _repo;
        private readonly IMapper _mapper;

        #endregion

        #region constracturs
        public SubjectCommandHandler(IUnitOfWork repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        #endregion

        #region Handlers

        public async Task<Response<string>> Handle(SubjectCreateRequest request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Subject>(request);
            await _repo.Subject.AddAsync(model);
            await _repo.SaveChangesAsync();

            return Created("created successfully");


        }
        #endregion
    }
}
