﻿using ExamMaster.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Application.Contracts.IServices
{
    public interface IStudentExamFactory
    {
        StudentExam CreateStudentExam(string studentId, int examId, int totalPoint, decimal scoreRate, bool isSuccess);
    }
}
