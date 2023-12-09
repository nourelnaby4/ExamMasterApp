using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Domain.Entities
{
    public class Subject
    {
        public Subject() { 

            Levels = new HashSet<Level>();
        }
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }

        public int TotalPoint { get; set; } = 0;

        public virtual ICollection<Level> Levels { get; set;}
    }
}
