using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuizApp.Data.Entities.ViewModels
{
	public class QuestionViewModel
	{
		[Required]
		public string Title { get; set; }
		[Required]
		public int QuizId { get; set; }
		[Required]
		public int CorrectAnswerIndex { get; set; }
		public AnswerViewModel CorrectAnswer { get; set; }
		public ICollection<AnswerViewModel> Answers { get; set; }
	}
}
