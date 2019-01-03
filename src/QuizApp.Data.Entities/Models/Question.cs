using QuizApp.Data.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApp.Data.Entities.Models
{
	public class Question: BaseModel
	{

		[Required]
		public string Title { get; set; }
		[Required]
		public int QuizId { get; set; }
		[ForeignKey("QuizId")]
		public Quiz Quiz { get; set; }
		public int? CorrectAnswerId { get; set; }
		[ForeignKey("CorrectAnswerId")]
		public Answer CorrectAnswer { get; set; }
		public ICollection<Answer> Answers { get; set; }
	}
}
