using ExamMaster.Application.Contracts.IServices;
using ExamMaster.Application.Features.Exams.Commands.Models.Requests;
using ExamMaster.Application.Features.Questions.MultiChoice.Commands.Models.ViewModel;
using ExamMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Features.Exams.Commands.Services
{
    public class ExamCalculator : IExamCalculator
    {
        public int CalculateTotalPoint(IEnumerable<ChoiceQuestion> studentChoiceAnswers, IEnumerable<QuestionsChoiceCorrectAnswer> multiChoiceModelAnswer)
        {
            int totalPoints = default;
            foreach (var modelAnswer in multiChoiceModelAnswer)
            {
                var studentAnswer = studentChoiceAnswers.SingleOrDefault(x => x.Answers.QuestionId == modelAnswer.QuestionId);
                if (studentAnswer != null && modelAnswer.AnswerId == studentAnswer.Answers.ChoiceId)
                    totalPoints += modelAnswer.QuestionPoint;
            }

            return totalPoints;
        }
        public decimal CalculateStudentScoreRate(decimal examSuccessRate, int studentExamtotalPoints, int ExamtotalPoints)
        {
            return studentExamtotalPoints / ExamtotalPoints * 100;
        }
        public bool CalculateIsSuccess(decimal examSuccessRate, decimal scaoreRate)
        {
            return examSuccessRate >= scaoreRate;
        }
    }
}
