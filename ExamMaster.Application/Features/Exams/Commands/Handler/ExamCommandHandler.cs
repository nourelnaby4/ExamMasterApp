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
                                     IRequestHandler<ExamEditRequest, Response<string>>

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
            var trasn = _repo.BeginTransaction();
            try
            {

                var exam = _mapper.Map<Exam>(request);
                await _repo.Exam.AddAsync(exam);

                var subjectLevel = new SubjectLevel()
                {
                    SubjectId = request.SubjectId,
                    LevelId = request.LevelId,
                    Exam = exam
                };

                await _repo.SubjectLevel.AddAsync(subjectLevel);


                await _repo.SaveChangesAsync();
                await trasn.CommitAsync(cancellationToken);

                return Created("Success");
            }
            catch (Exception ex)
            {
                await trasn.RollbackAsync();
                throw;
            }

        }

        public async Task<Response<string>> Handle(ExamEditRequest request, CancellationToken cancellationToken)
        {
            var trasn = _repo.BeginTransaction();
            try
            {
                var exam = await _repo.Exam.GetTableAsTracking()
                    .Include(x=>x.SubjectLevel)
                    .SingleOrDefaultAsync(x=>x.Id==request.Id);

                var examEdited = _mapper.Map( request ,exam);
                 _repo.Exam.Update(examEdited);
                 _repo.SubjectLevel.Update(examEdited.SubjectLevel);
                await _repo.SaveChangesAsync();


                await _repo.SaveChangesAsync();
                await trasn.CommitAsync(cancellationToken);

                return EditSuccess("Success");
            }
            catch (Exception ex)
            {
                await trasn.RollbackAsync();
                throw;
            }
        }
        #endregion

    }
}
