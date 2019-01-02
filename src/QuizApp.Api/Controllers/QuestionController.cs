using Microsoft.AspNetCore.Mvc;
using QuizApp.Api.Common;
using QuizApp.Data.Entities.Models;
using QuizApp.Data.Services.UnitOfWork;

namespace QuizApp.Api.Controllers
{
	[Produces("application/json")]
	public class QuestionController : CommonOdataController<Question>
	{
		public QuestionController(QuizAppUnitOfWork unitOfWork) : base(unitOfWork)
		{
			CrudRepository = unitOfWork.QuestionRepository;
		}
	}
}