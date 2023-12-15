using AutoMapper;
using AVMS.Application.Common.Model;
using ExamMaster.Application.Contracts;
using ExamMaster.Application.Features.Questions.MultiChoices.Commands.Models.Requsets;
using ExamMaster.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Questions.MultiChoices.Commands.Handerls
{
    public class MultiChoiceCommandHandler : ResponseHandler,
                                             IRequestHandler<MultiChoiceCreateRequest, Response<string>>
    {
        #region fields
        private readonly IUnitOfWork _repo;
        private readonly IMapper _mapper;
        #endregion


        #region constructor
        public MultiChoiceCommandHandler(IUnitOfWork repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
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


        #endregion

    }
}
