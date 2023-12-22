using AutoMapper;
using AVMS.Application.Common.Model;
using ExamMaster.Application.Contracts.Repos;
using ExamMaster.Application.Features.Levels.Queries.Models.Requests;
using ExamMaster.Application.Features.Levels.Queries.Models.Response;
using ExamMaster.Application.Features.Subjects.Queries.Models.Response;
using ExamMaster.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Levels.Queries.Handlers
{
    public class LevelQueryHandler : ResponseHandler,
                                       IRequestHandler<LevelGetAllRequest, Response<IEnumerable<LevelGetResponse>>>,
                                       IRequestHandler<LevelGetByIdRequest, Response<LevelGetResponse>>
         

    {

        #region fields
        private readonly IUnitOfWork _repo;
        private readonly IMapper _mapper;

        #endregion

        #region constracturs
        public LevelQueryHandler(IUnitOfWork repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        #endregion


        #region handlers
        public async Task<Response<LevelGetResponse>> Handle(LevelGetByIdRequest request, CancellationToken cancellationToken)
        {
            var level = await _repo.Level.GetByIdAsync(request.Id);
            if (level is null)
                return BadRequest<LevelGetResponse>("subject is not found");

            var response= _mapper.Map<LevelGetResponse>(level);
            return Success( response);
        }

        public async Task<Response<IEnumerable<LevelGetResponse>>> Handle(LevelGetAllRequest request, CancellationToken cancellationToken)
        {
            var level = await _repo.Level.GetAllAsync();
            if (level.Count() == 0)
                return Success(new List<LevelGetResponse>().AsEnumerable());

            var response = _mapper.Map<IEnumerable< LevelGetResponse>>(level);
            return Success(response);
        }
        #endregion



      
    }
}
