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

        public int TotalPoint { get; set; } = 0;

        [ForeignKey(nameof(SubjectId))]
        public Subject Subject { get; set; }

        [ForeignKey(nameof(LevelId))]
        public Level Level { get; set; }

    }
}
