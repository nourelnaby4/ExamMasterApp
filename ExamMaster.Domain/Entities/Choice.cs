using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ExamMaster.Domain.Entities
{
    public class Choice
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string Content { get; set; }

        [JsonIgnore]
        public bool IsCorrect { get; set; }
        [JsonIgnore]
        public int QuestionId { get; set; }

        [ForeignKey(nameof(QuestionId))]
        [InverseProperty(nameof(Question.Choices))]
        [JsonIgnore]
        public Question Question { get; set; }



    }
}
