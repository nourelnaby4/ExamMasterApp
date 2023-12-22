using AutoMapper;
using AVMS.Application.Common.Model;
using ExamMaster.Application.Common.Enums.Constents;
using ExamMaster.Application.Contracts.IServices;
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
                                     IRequestHandler<StudentExamAnswerRequest, Response<StudentExamAnswerResponse>>



    {
        #region fields
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _repo;
        private readonly IExamCalculator _examCalculator;
        private readonly IStudentExamFactory _studentExamFactory;

        #endregion

        #region constructor
        public ExamCommandHandler(IMapper mapper, IUnitOfWork repo, IStudentExamFactory studentExamFactory,IExamCalculator examCalculator)
        {
            _mapper = mapper;
            _repo = repo;
            _studentExamFactory = studentExamFactory;
            _examCalculator = examCalculator;
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

        public async Task<Response<StudentExamAnswerResponse>> Handle(StudentExamAnswerRequest request, CancellationToken cancellationToken)
        {
            var studentChoiceAnswers = request.QuestionType.ChoiceQuestions;
            if (studentChoiceAnswers is null)
            {
                return BadRequest<StudentExamAnswerResponse>("Choice Answer not Valid!");
            }

            var multiChoiceModelAnswer = await _repo.Exam.GetMultiChoiceAnswer(request.ExamId);
            var exam = await _repo.Exam.GetByIdAsync(request.ExamId);
            var resultTotalPoint = _examCalculator.CalculateTotalPoint(studentChoiceAnswers, multiChoiceModelAnswer);
            var ScoreRate = _examCalculator.CalculateStudentScoreRate(exam.ExamSuccessRate, resultTotalPoint, exam.TotalPoints);
            var isSuccess = _examCalculator.CalculateIsSuccess(exam.ExamSuccessRate, ScoreRate);

            var studentExam = _studentExamFactory.CreateStudentExam(
            studentId: "0a57d142-d912-4cdc-a183-c1a4e63f36db", //:TODO Create Student endPoint
            examId: request.ExamId,
            totalPoint: resultTotalPoint,
            scoreRate: ScoreRate,
            isSuccess: isSuccess
          );

            await _repo.StudentExam.AddAsync(studentExam);
            await _repo.SaveChangesAsync();

            var resposne = _mapper.Map<StudentExamAnswerResponse>(studentExam);

            return Success<StudentExamAnswerResponse>(resposne);
        }

        #endregion

    }


}
