using System.ComponentModel.DataAnnotations;

namespace QuizApp.Data.Entities.ViewModels
{
	public class AnswerViewModel
	{
		[Required]
		public string Choice { get; set; }
		public string Explanation { get; set; }
	}
}
