using AutoMapper;
using AVMS.Application.Common.Model;
using ExamMaster.Application.Common.Extentions;
using ExamMaster.Application.Common.Model;
using ExamMaster.Application.Contracts;
using ExamMaster.Application.Features.Questions.MultiChoice.Queries.Models.Requests;
using ExamMaster.Application.Features.Questions.MultiChoice.Queries.Models.Response;
using ExamMaster.Domain.Entities;
using MediatR;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Questions.MultiChoice.Queries.Handlers
{
    public class QuestionQueryHandler : ResponseHandler,
                                           IRequestHandler<QuestionGetRequest, Response<PaginatedResult<QuestionGetResponse>>>,
                                           IRequestHandler<QuestionGroupingRequest, Response<IEnumerable<QuestionGroupResponse>>>
       
    {
        #region field
        private readonly IUnitOfWork _repo;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;
        
        #endregion

        #region consructor
        public QuestionQueryHandler(IUnitOfWork repo, IMapper mapper, ICacheService cacheService)
        {
            _repo = repo;
            _mapper = mapper;
            _cacheService = cacheService;
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

        public async Task<Response<IEnumerable<QuestionGroupResponse>>> Handle(QuestionGroupingRequest request, CancellationToken cancellationToken)
        {
            var Questions = await _repo.Question.GetQuestions($"Questions-Exam-{request.ExamId}", _cacheService);
            return Success(Questions);
        }


        #endregion


    }
}
