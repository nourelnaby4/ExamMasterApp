using AutoMapper;
using AVMS.Application.Common.Model;
using ExamMaster.Application.Common.Enums.Constents;
using ExamMaster.Application.Contracts.IServices;
using ExamMaster.Application.Contracts.IServices.AuthServices;
using ExamMaster.Application.Contracts.Repos;
using ExamMaster.Application.Features.Exams.Commands.Models.Reponse;
using ExamMaster.Application.Features.Exams.Commands.Models.Requests;
using ExamMaster.Application.Features.Exams.Commands.Services;
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
                                     IRequestHandler<ExamDeleteRequest, Response<string>>,
                                     IRequestHandler<ExamSubmitAnswerRequest, Response<ExamSubmitAnswerResponse>>



    {
        #region fields
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _repo;
        private readonly IExamCalculator _examCalculator;
        private readonly IStudentExamFactory _studentExamFactory;
        private readonly IAuthService _authService;

        #endregion

        #region constructor
        public ExamCommandHandler(IMapper mapper, IUnitOfWork repo, IStudentExamFactory studentExamFactory,IExamCalculator examCalculator,IAuthService authService)
        {
            _mapper = mapper;
            _repo = repo;
            _studentExamFactory = studentExamFactory;
            _examCalculator = examCalculator;
            _authService = authService;
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
            if (exam is null)
                return NotFound<string>("exam not found");


            var model = _mapper.Map(request, exam);
            _repo.Exam.Update(model);
            await _repo.SaveChangesAsync();
            return EditSuccess("Success");
        }
        public async Task<Response<string>> Handle(ExamDeleteRequest request, CancellationToken cancellationToken)
        {
            var exam = await _repo.Exam.GetByIdAsync(request.Id);
            if (exam is null)
                return NotFound<string>("exam not found");

            _repo.Exam.Update(exam);
            await _repo.SaveChangesAsync();
            return Deleted<string>();
        }

        public async Task<Response<ExamSubmitAnswerResponse>> Handle(ExamSubmitAnswerRequest request, CancellationToken cancellationToken)
        {
            var userId = _authService.GetUserId(request.UserClaims);
            if (userId is null)
                throw new UnauthorizedAccessException();

            var studentChoiceAnswers = request.ViewModel.QuestionType.ChoiceQuestions;
            if (studentChoiceAnswers is null)
            {
                return BadRequest<ExamSubmitAnswerResponse>("Choice Answer not Valid!");
            }

            var multiChoiceModelAnswer = await _repo.Exam.GetMultiChoiceAnswer(request.ViewModel.ExamId);
            var exam = await _repo.Exam.GetByIdAsync(request.ViewModel.ExamId);
            var resultTotalPoint = _examCalculator.CalculateTotalPoint(studentChoiceAnswers, multiChoiceModelAnswer);
            var ScoreRate = _examCalculator.CalculateStudentScoreRate(exam.ExamSuccessRate, resultTotalPoint, exam.TotalPoints);
            var isSuccess = _examCalculator.CalculateIsSuccess(exam.ExamSuccessRate, ScoreRate);
            
            //Create ExamStudentModel
            var studentExam = _studentExamFactory.CreateStudentExam(
            studentId: userId,
            examId: request.ViewModel.ExamId,
            totalPoint: resultTotalPoint,
            scoreRate: ScoreRate,
            isSuccess: isSuccess
          );

            await _repo.StudentExam.AddAsync(studentExam);
            await _repo.SaveChangesAsync();

            var resposne = _mapper.Map<ExamSubmitAnswerResponse>(studentExam);

            return Success<ExamSubmitAnswerResponse>(resposne);
        }

        #endregion

    }


}
