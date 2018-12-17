using Microsoft.AspNetCore.Identity;
using QuizApp.Data.Dal.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QuizApp.Data.Dal.Models
{
	public class QuizResult : BaseModel
	{
		public int Score { get; set; }

		[ForeignKey("Quiz")]
		public int QuizId { get; set; }
		public IdentityUser User { get; set; }
	}
}
