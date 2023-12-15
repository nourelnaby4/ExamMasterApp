using AutoMapper;
using AVMS.Application.Common.Model;
using ExamMaster.Application.Contracts;
using ExamMaster.Application.Features.Exams.Commands.Models;
using ExamMaster.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Exams.Commands.Handler
{
    public class ExamCommandHandler : ResponseHandler,
                                     IRequestHandler<ExamCreateRequest, Response<string>>,
                                     IRequestHandler<ExamEditRequest, Response<string>>,
                                     IRequestHandler<ExamDeleteRequest, Response<string>>

    {
        #region fields
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _repo;
        #endregion

        #region constructor
        public ExamCommandHandler(IMapper mapper, IUnitOfWork repo)
        {
            _mapper = mapper;
            _repo = repo;
        }
        #endregion



        #region actions
        public async Task<Response<string>> Handle(ExamCreateRequest request, CancellationToken cancellationToken)
        {
            var exam = _mapper.Map<Exam>(request);
            await _repo.Exam.AddAsync(exam);
            await _repo.SaveChangesAsync();
            return Created("Success");

        }
        public async Task<Response<string>> Handle(ExamEditRequest request, CancellationToken cancellationToken)
        {
            var exam = await _repo.Exam.GetByIdAsync(request.Id);

            if (exam != null)
            {
                var model = _mapper.Map(request, exam);
                _repo.Exam.Update(model);
                await _repo.SaveChangesAsync();

                return EditSuccess("Success");
            }
            else
            {
                return NotFound<string>("exam not found");
            }
        }

        public async Task<Response<string>> Handle(ExamDeleteRequest request, CancellationToken cancellationToken)
        {
            var exam = await _repo.Exam.GetByIdAsync(request.Id);

            if (exam != null)
            {
               
                _repo.Exam.Update(exam);
                await _repo.SaveChangesAsync();

                return Deleted<string>();
            }
            else
            {
                return NotFound<string>("exam not found");
            }
        }
        #endregion

    }
}
