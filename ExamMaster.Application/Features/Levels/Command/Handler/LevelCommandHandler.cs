using AutoMapper;
using AVMS.Application.Common.Model;
using ExamMaster.Application.Contracts.Repos;
using ExamMaster.Application.Features.Levels.Command.Model.Requests;
using ExamMaster.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Levels.Command.Handler
{
    public class LevelCommandHandler : ResponseHandler,
                                        IRequestHandler<LevelCreateRequest, Response<string>>,
                                        IRequestHandler<LevelEditRequest, Response<string>>,
                                        IRequestHandler<LevelDeleteRequest, Response<string>>

    {

        #region fields
        private readonly IUnitOfWork _repo;
        private readonly IMapper _mapper;

        #endregion

        #region constracturs
        public LevelCommandHandler(IUnitOfWork repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        #endregion

        #region Handlers

        public async Task<Response<string>> Handle(LevelCreateRequest request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Level>(request);
            await _repo.Level.AddAsync(model);
            await _repo.SaveChangesAsync();

            return Created("created successfully");


        }

        public async Task<Response<string>> Handle(LevelEditRequest request, CancellationToken cancellationToken)
        {
            var subject = await _repo.Level.GetByIdAsync(request.Id);

            if (subject == null)
                return BadRequest<string>("Subject is not found");

            var model = _mapper.Map(request, subject);
            _repo.Level.Update(model);
            await _repo.SaveChangesAsync();

            return EditSuccess("Edit successfully");
        }

        public async Task<Response<string>> Handle(LevelDeleteRequest request, CancellationToken cancellationToken)
        {
            var subject = await _repo.Level.GetByIdAsync(request.Id);

            if (subject == null)
                return BadRequest<string>("Subject is not found");

            
            _repo.Level.Delete(subject);
            await _repo.SaveChangesAsync();

            return Deleted<string>();
        }
        #endregion
    }
}
