using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Domain.Entities
{
    public class QuestionType
    {
        public QuestionType()
        {
            Questions = new HashSet<Question>();
        }
        [Key]
        public int Id { get; set; }

        [StringLength(30)]
        public string TypeName { get; set; }

        [InverseProperty(nameof(Question.QuestionType))]
        public virtual ICollection<Question> Questions { get; set; }
    }
}
