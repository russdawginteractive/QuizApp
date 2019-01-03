using Microsoft.AspNetCore.Mvc;
using QuizApp.Api.Common;
using QuizApp.Data.Entities.Models;
using QuizApp.Data.Services.UnitOfWork;

namespace QuizApp.Api.Controllers
{
	[Produces("application/json")]
	public class AnswerController : CommonOdataController<Answer>
	{
		public AnswerController(QuizAppUnitOfWork unitOfWork) : base(unitOfWork)
		{
			CrudRepository = unitOfWork.AnswerRepository;
		}
	}
}