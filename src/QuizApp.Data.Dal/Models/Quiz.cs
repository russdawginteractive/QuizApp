using QuizApp.Data.Dal.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuizApp.Data.Dal.Models
{
	public class Quiz: BaseModel
	{
		[Required]
		public string Title { get; set; }
		[Required]
		public string Description { get; set; }
		[StringLength(10)]
		public string EventId { get; set; }
		public ICollection<Question> Questions { get; set; }
	}
}
