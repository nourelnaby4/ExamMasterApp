using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamMaster.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
       
    }
}
