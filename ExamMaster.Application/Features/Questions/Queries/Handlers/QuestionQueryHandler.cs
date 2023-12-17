using AutoMapper;
using AVMS.Application.Common.Model;
using ExamMaster.Application.Common.Extentions;
using ExamMaster.Application.Common.Model;
using ExamMaster.Application.Contracts;
using ExamMaster.Application.Features.Questions.Queries.Models.Requests;
using ExamMaster.Application.Features.Questions.Queries.Models.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Questions.Queries.Handlers
{
    public class QuestionQueryHandler : ResponseHandler,
                                           IRequestHandler<QuestionGetRequest, Response<PaginatedResult<QuestionGetResponse>>>
    {
        #region field
        private readonly IUnitOfWork _repo;
        private readonly IMapper _mapper;
        #endregion

        #region consructor
        public QuestionQueryHandler(IUnitOfWork repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        #endregion


        #region handlers

        public async Task<Response<PaginatedResult<QuestionGetResponse>>> Handle(QuestionGetRequest request, CancellationToken cancellationToken)
        {
            var QuestionsAsQueryable = _repo.Question.GetQueryable(request.ExamId);
            var QuestionModelAsQueryable = _mapper.ProjectTo<QuestionGetResponse>(QuestionsAsQueryable);
            var result = await QuestionModelAsQueryable.ToPaginatedListAsync(request.PageNumber, request.PageSize);

            return Success(result);
        }
        #endregion


    }
}
