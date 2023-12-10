using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Domain.Entities
{
    public class SubjectLevel
    {
        [Key]
        public int SubjectId { get; set; }

        [Key]
        public int LevelId { get; set; }

        public int? ExamId { get; set; }
        [ForeignKey(nameof(ExamId))]
        [InverseProperty(nameof(Exam.SubjectLevel))]
        public virtual Exam? Exam {  get; set; } 

        [ForeignKey(nameof(SubjectId))]
        [InverseProperty(nameof(Subject.SubjectLevels))]
        public Subject Subject { get; set; }

        [ForeignKey(nameof(LevelId))]
        [InverseProperty(nameof(Level.SubjectLevels))]
        public Level Level { get; set; }

    }
}
