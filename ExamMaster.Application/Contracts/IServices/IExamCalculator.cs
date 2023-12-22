using ExamMaster.Application.Features.Exams.Commands.Models.Requests;
using ExamMaster.Application.Features.Questions.MultiChoice.Commands.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Contracts.IServices
{
    public interface IExamCalculator
    {
        int CalculateTotalPoint(IEnumerable<ChoiceQuestion> studentChoiceAnswers, IEnumerable<QuestionsChoiceCorrectAnswer> multiChoiceModelAnswer);
        decimal CalculateStudentScoreRate(decimal examSuccessRate, int studentExamtotalPoints, int ExamtotalPoints);
        bool CalculateIsSuccess(decimal examSuccessRate, decimal scaoreRate);
    }
}
