using QuizApp.Data.Entities.Models;
using QuizApp.Data.Services.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuizApp.UnitTest.XUnitTesting.Static
{
	public static class SeedHelper
	{
		public static void SeedQuestionsAndAnswers(QuizAppUnitOfWork unitOfWork)
		{
			Quiz quiz = new Quiz
			{
				Title = "Test Quiz",
				Description = "This is a simple test.",
				EventId = "1234",


			};
			List<Question> questions = new List<Question>
			{
				new Question
				{
					Title ="This is Question One"
				}
			};

			List<Answer> answers = new List<Answer>
			{
				new Answer
				{
					Choice = "This is Answer Option One",
					Explanation = "This is not the correct Answer"
				},
				new Answer
				{
					Choice = "This is Answer Option Two",
					Explanation = "This is the CORRECT ANSWER"
				}
			};

			unitOfWork.QuizRepository.Create(quiz);
			var quizSaved = unitOfWork.Save();
			var newQuiz = unitOfWork.QuizRepository.GetFirst(x => x.Id == 1);
			questions.ForEach(x => {
				x.Quiz = newQuiz;
				unitOfWork.QuestionRepository.Create(x);
			});
			var questionsSaved = unitOfWork.Save();
			var newQuestion = unitOfWork.QuestionRepository.GetFirst(x => x.Id == 1);
			answers.ForEach(x => {
				x.Question = newQuestion;
				unitOfWork.AnswerRepository.Create(x);
			});
			var answersSaved = unitOfWork.Save();


		}
	}
}
