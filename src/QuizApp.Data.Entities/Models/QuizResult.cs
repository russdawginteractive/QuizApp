using Microsoft.AspNetCore.Identity;
using QuizApp.Data.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizApp.Data.Entities.Models
{
	public class QuizResult : BaseModel
	{
		public int Score { get; set; }

		[ForeignKey("Quiz")]
		public int QuizId { get; set; }
		public IdentityUser User { get; set; }
	}
}
