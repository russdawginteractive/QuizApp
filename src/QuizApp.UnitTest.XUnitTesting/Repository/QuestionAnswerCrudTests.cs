using QuizApp.Data.Dal.Models;
using QuizApp.Data.Services.UnitOfWork;
using QuizApp.UnitTest.XUnitTesting.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace QuizApp.UnitTest.XUnitTesting.Repository
{
	public class QuestionAnswerCrudTests:IClassFixture<DalContextFixture>
	{
		private readonly DalContextFixture _fixture;
		private readonly QuizAppUnitOfWork _uow;

		public QuestionAnswerCrudTests(DalContextFixture fixture)
		{
			_fixture = fixture;
			_uow = fixture.CreateUnitOfWork();
			SeedQuestionsAndAnswers();
		}

		private void SeedQuestionsAndAnswers()
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
					Title ="This is Question One",
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

			_uow.QuizRepository.Create(quiz);
			var quizSaved = _uow.Save();
			var newQuiz = _uow.QuizRepository.GetFirst(x => x.Id == 1);
			questions.ForEach(x => {
				x.Quiz = newQuiz;
				_uow.QuestionRepository.Create(x);
			});
			var questionsSaved = _uow.Save();
			var newQuestion = _uow.QuestionRepository.GetFirst(x => x.Id == 1);
			answers.ForEach(x => {
				x.Question = newQuestion;
				_uow.AnswerRepository.Create(x);
			});
			var answersSaved = _uow.Save();


		}
		[Fact]
		public void TestCreatesSeedWorked()
		{
			// Act
			int quizCount = _uow.QuizRepository.GetAll().Count();
			int questionCount = _uow.QuestionRepository.GetAll().Count();
			int answerCount = _uow.AnswerRepository.GetAll().Count();

			// Assert
			Assert.Equal(1, quizCount);
			Assert.Equal(1, questionCount);
			Assert.Equal(2, answerCount);
		}

		[Fact]
		public void TestSetCorrectAnswerSet()
		{
			// Setup
			Answer correctAnswer = _uow.AnswerRepository.GetFirst(x => x.Id == 2);
			Question question = _uow.QuestionRepository.GetFirst(x => x.Id == 1);

			// Act
			question.CorrectAnswer = correctAnswer;
			_uow.QuestionRepository.Update(question);
			var questionSaved = _uow.Save();
			question = _uow.QuestionRepository.GetFirst(x => x.Id == 1);
			var correctAnswerId = question.CorrectAnswerId;
			var correctAnswerTitle = question.CorrectAnswer.Choice;

			// Assert
			Assert.True(questionSaved);
			Assert.Equal(2, correctAnswerId);
			Assert.Equal("This is Answer Option Two", correctAnswerTitle);

		}
	}
}
