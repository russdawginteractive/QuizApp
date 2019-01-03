using QuizApp.Data.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApp.Data.Entities.Models
{
	public class Answer : BaseModel
	{
		[Required]
		public string Choice { get; set; }
		public string Explanation { get; set; }
		public int QuestionId { get; set; }

		[ForeignKey("QuestionId")]
		public Question Question {get; set;}
	}
}
