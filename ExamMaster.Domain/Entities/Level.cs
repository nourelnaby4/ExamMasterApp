using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Domain.Entities
{
    public class Level
    {
        public Level()
        {
            SubjectLevels = new HashSet<SubjectLevel>();
        }
        public int Id { get; set; }

        [MaxLength(60)]
        public string Name { get; set; }


        [InverseProperty(nameof(SubjectLevel.Level))]
        public virtual ICollection<SubjectLevel> SubjectLevels { get; set; }
    }
}
