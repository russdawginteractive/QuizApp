using QuizApp.Data.Entities.Models;
using QuizApp.Data.Entities.ViewModels;
using QuizApp.Middleware.Services.Interface;
using System;
using System.Collections.Generic;

namespace QuizApp.Middleware.Services
{
	public class QuestionService : IQuestionService
	{
		public IEnumerable<Question> ConvertQuestion(IEnumerable<QuestionViewModel> questionViewModelList)
		{
			throw new NotImplementedException();
		}
	}
}
