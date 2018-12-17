using QuizApp.Data.Dal.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApp.Data.Dal.Models
{
	public class Question: BaseModel
	{

		[Required]
		public string Title { get; set; }
		public int? CorrectAnswerId { get; set; }
		[ForeignKey("CorrectAnswerId")]
		public Answer CorrectAnswer { get; set; }
		public ICollection<Answer> Answers { get; set; }
	}
}
