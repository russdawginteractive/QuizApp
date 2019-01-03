using QuizApp.Data.Entities.Models;
using QuizApp.Data.Services.UnitOfWork;
using QuizApp.UnitTest.XUnitTesting.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace QuizApp.UnitTest.XUnitTesting.Repository
{
	public class QuizCrudTests:IClassFixture<DalContextFixture>
	{
		private readonly DalContextFixture _fixture;
		private readonly Quiz _simpleQuiz;
		private readonly string _guidEventId;

		public QuizCrudTests(DalContextFixture fixture)
		{
			_fixture = fixture;
			_guidEventId = new Guid().ToString();
			_simpleQuiz = new Quiz
			{
				Title = "Test Quiz",
				Description = "This is a simple test.",
				EventId = _guidEventId
			};
			
		}
		[Fact]
		public async void TestCreateQuizAsync()
		{
			var blnSucceeded = false;
			string strExceptionMessage = string.Empty;
			int? actualId = null;

			// Act
			try
			{
				using (var uow = _fixture.CreateUnitOfWork(false))
				{
					DeleteExistingQuizzes(uow);
					uow.QuizRepository.Create(_simpleQuiz);
					blnSucceeded = await uow.Save();

					var quiz = uow.QuizRepository.GetAll().FirstOrDefault();
					if (quiz != null)
					{
						actualId = quiz.Id;
					}
				}
				//_fixture.Dispose();
			}
			catch (Exception ex)
			{
				blnSucceeded = false;
				strExceptionMessage = ex.Message;
				
			}

			//Assert
			Assert.True(blnSucceeded, strExceptionMessage);
			Assert.NotNull(actualId);
			Assert.True(actualId > 1);
		}

		[Fact]
		public async void TestUpdateQuizAsync()
		{
			var blnSucceeded = false;
			string strExceptionMessage = string.Empty;
			int actualId = 0;
			string expectedEventId = new Guid().ToString();
			string expectedTitle = "This is the Quiz One New Title";
			string actualEventId = string.Empty;
			string actualTitle = string.Empty;

			
			// Act
			try
			{
				using (var uow = _fixture.CreateUnitOfWork(false))
				{
					DeleteExistingQuizzes(uow);
					uow.QuizRepository.Create(_simpleQuiz);
					await uow.Save();

					var quiz = uow.QuizRepository.GetAll().FirstOrDefault();
					
					quiz.Title = expectedTitle;
					quiz.EventId = expectedEventId;
					uow.QuizRepository.Update(quiz);
					blnSucceeded = await uow.Save();
					var updatedQuiz = uow.QuizRepository.GetAll().FirstOrDefault();
					actualId = updatedQuiz.Id;
					actualEventId = updatedQuiz.EventId;
					actualTitle = updatedQuiz.Title;

				}
				//_fixture.Dispose();
			}
			catch (Exception ex)
			{
				blnSucceeded = false;
				strExceptionMessage = ex.Message;

			}

			//Assert
			Assert.True(blnSucceeded, strExceptionMessage);
			Assert.True(actualId > 0);
			Assert.Equal(expectedTitle, actualTitle);
			Assert.Equal(expectedEventId, actualEventId);
		}

		[Fact]
		public async void TestDeleteQuizByIdAsync()
		{
			var blnSucceeded = false;
			string strExceptionMessage = string.Empty;
			int actualId = 0;
			Quiz actualDeletedRecord = _simpleQuiz; // Should return null in query after delete.

			// Act
			try
			{
				using (var uow = _fixture.CreateUnitOfWork(false))
				{
					DeleteExistingQuizzes(uow);
					uow.QuizRepository.Create(_simpleQuiz);
					await uow.Save();

					var quiz = uow.QuizRepository.GetAll().FirstOrDefault();
					actualId = quiz.Id;

					uow.QuizRepository.Delete(actualId);
					blnSucceeded = await uow.Save();
					actualDeletedRecord = uow.QuizRepository.GetFirst(x => x.Id == actualId);

					// Re-create the quiz as other test quizzes are failing.
					uow.QuizRepository.Create(_simpleQuiz);
					await uow.Save();
					quiz = uow.QuizRepository.GetAll().FirstOrDefault();
					actualId = quiz.Id;

				}
				//_fixture.Dispose();
			}
			catch (Exception ex)
			{
				blnSucceeded = false;
				strExceptionMessage = ex.Message;

			}

			//Assert
			Assert.True(blnSucceeded, strExceptionMessage);
			Assert.True(actualId > 0);
			Assert.Null(actualDeletedRecord);
		}

		
		[Fact]
		public async void TestDeleteQuizByExpresion_ExpectNotImplementedAsync()
		{
			var blnSucceeded = false;
			string strExceptionMessage = string.Empty;
			int actualId = 0;
			bool exceptionThrown = false;
			string exceptionMsg = string.Empty;

			// Act
			try
			{
				using (var uow = _fixture.CreateUnitOfWork(false))
				{
					DeleteExistingQuizzes(uow);
					uow.QuizRepository.Create(_simpleQuiz);
					await uow.Save();

					var quiz = uow.QuizRepository.GetAll().FirstOrDefault();
					actualId = quiz.Id;

					uow.QuizRepository.Delete(x => x.Id == actualId);
					blnSucceeded = await uow.Save();

				}
				//_fixture.Dispose();
			}
			catch (NotImplementedException niEx)
			{
				exceptionThrown = true;
				exceptionMsg = niEx.Message;
				using (var uow = _fixture.CreateUnitOfWork(false))
				{
					DeleteExistingQuizzes(uow);
				}

			}
			catch (Exception ex)
			{
				blnSucceeded = false;
				strExceptionMessage = ex.Message;
				using (var uow = _fixture.CreateUnitOfWork(false))
				{
					DeleteExistingQuizzes(uow);
				}

			}

			//Assert
			Assert.True(exceptionThrown, strExceptionMessage);
			Assert.False(blnSucceeded, strExceptionMessage);
			Assert.True(actualId > 0);
		}


		private async void DeleteExistingQuizzes(QuizAppUnitOfWork uow)
		{
			List<Quiz> quizzes = uow.QuizRepository.GetAll().ToList();
			if (quizzes.Count > 0)
			{
				foreach (var quiz in quizzes)
				{
					uow.QuizRepository.Delete(quiz.Id);
				}
				await uow.Save();
			}
			
		}
	}
}
