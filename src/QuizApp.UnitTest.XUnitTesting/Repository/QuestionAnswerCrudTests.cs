using QuizApp.Data.Entities.Models;
using QuizApp.Data.Services.UnitOfWork;
using QuizApp.UnitTest.XUnitTesting.Fixture;
using QuizApp.UnitTest.XUnitTesting.Static;
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
			//SeedHelper.SeedQuestionsAndAnswers(_uow);
		}

		
		[Fact]
		public void TestCreatesSeedWorked()
		{
			// Act
			int quizCount = _uow.QuizRepository.GetAll().Count();
			int questionCount = _uow.QuestionRepository.GetAll().Count();
			int answerCount = _uow.AnswerRepository.GetAll().Count();
			_fixture.Dispose();
			// Assert
			Assert.Equal(1, quizCount);
			Assert.Equal(1, questionCount);
			Assert.Equal(2, answerCount);
		}

		[Fact]
		public async void TestSetCorrectAnswerSetAsync()
		{
			// Setup
			Answer correctAnswer = _uow.AnswerRepository.GetFirst(x => x.Id == 2);
			Question question = _uow.QuestionRepository.GetFirst(x => x.Id == 1);

			// Act
			question.CorrectAnswer = correctAnswer;
			question.CorrectAnswerId = correctAnswer.Id;
			_uow.QuestionRepository.Update(question);
			var questionSaved = await _uow.Save();
			question = _uow.QuestionRepository.GetFirst(x => x.Id == 1);
			var correctAnswerId = question.CorrectAnswerId;
			var correctAnswerTitle = question.CorrectAnswer.Choice;
			_fixture.Dispose();

			// Assert
			Assert.True(questionSaved);
			Assert.Equal(2, correctAnswerId);
			Assert.Equal("This is Answer Option Two", correctAnswerTitle);

		}
	}
}
