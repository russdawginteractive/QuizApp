using QuizApp.Data.Entities.Models;
using QuizApp.Data.Entities.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp.Middleware.Services.Interface
{
	public interface IQuestionService
	{
		IEnumerable<Question> ConvertQuestion(IEnumerable<QuestionViewModel> questionViewModelList);
	}
}
