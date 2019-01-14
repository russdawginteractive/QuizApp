using QuizApp.Data.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuizApp.Data.Entities.Models
{
	public class Quiz: BaseModel
	{
		[Required]
		public string Title { get; set; }
		[Required]
		public string Description { get; set; }
		[StringLength(10)]
		public string EventId { get; set; }
		[DisplayName("YouTube URL")]
		public string PathToQuizReference { get; set; }
		[DefaultValue(false)]
		public bool Active { get; set; }
		public ICollection<Question> Questions { get; set; }
	}
}
