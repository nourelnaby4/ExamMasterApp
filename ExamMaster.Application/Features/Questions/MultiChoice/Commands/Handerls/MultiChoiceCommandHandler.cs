using AutoMapper;
using AVMS.Application.Common.Model;
using ExamMaster.Application.Contracts;
using ExamMaster.Application.Features.Questions.MultiChoice.Commands.Models.Requsets;
using ExamMaster.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Questions.MultiChoice.Commands.Handerls
{
    public class MultiChoiceCommandHandler : ResponseHandler,
                                             IRequestHandler<MultiChoiceCreateRequest, Response<string>>,
                                             IRequestHandler<MultiChoiceEditRequest, Response<string>>,
                                             IRequestHandler<MultiChoiceDeleteRequest, Response<string>>
    {
        #region fields
        private readonly IUnitOfWork _repo;
        private readonly IMapper _mapper;
        private readonly ICacheService _cacheService;
        #endregion


        #region constructor
        public MultiChoiceCommandHandler(IUnitOfWork repo, IMapper mapper, ICacheService cacheService)
        {
            _repo = repo;
            _mapper = mapper;
            _cacheService = cacheService;
        }
        #endregion


        #region handler

        public async Task<Response<string>> Handle(MultiChoiceCreateRequest request, CancellationToken cancellationToken)
        {
            var trans = _repo.BeginTransaction();
            try
            {

                var question = _mapper.Map<Question>(request);
                await _repo.Question.AddAsync(question);
                foreach (var choice in question.Choices)
                {
                    choice.Question = question;
                }
                await _repo.Chioce.AddRangeAsync(question.Choices);
                await _repo.SaveChangesAsync();
                trans.Commit();
                return Created("success");
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw;
            }
        }

        public async Task<Response<string>> Handle(MultiChoiceEditRequest request, CancellationToken cancellationToken)
        {
            var trans = _repo.BeginTransaction();
            try
            {
                var question = await _repo.Question.GetMultiChoiceById(request.QuestionId);
                var questionMapping = _mapper.Map(request, question);
                _repo.Question.Update(questionMapping);
                foreach (var choice in questionMapping.Choices)
                {
                    choice.Question = question;
                }
                _repo.Chioce.UpdateRange(question.Choices);
                await _repo.SaveChangesAsync();
                trans.Commit();
                return EditSuccess("success");
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw;
            }
        }

        public async Task<Response<string>> Handle(MultiChoiceDeleteRequest request, CancellationToken cancellationToken)
        {
            var trans = _repo.BeginTransaction();
            try
            {
                var question = await _repo.Question.GetMultiChoiceById(request.QuestionId);
                _repo.Question.Delete(question);
                _repo.Chioce.DeleteRange(question.Choices);
                await _repo.SaveChangesAsync();
                trans.Commit();

                return Deleted<string>();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw;
            }
        }


        #endregion

    }
}
