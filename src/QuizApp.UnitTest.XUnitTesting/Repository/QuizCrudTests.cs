﻿using QuizApp.Data.Dal.Models;
using QuizApp.UnitTest.XUnitTesting.Fixture;
using System;
using System.Linq;
using Xunit;

namespace QuizApp.UnitTest.XUnitTesting.Repository
{
	public class QuizCrudTests:IClassFixture<DalContextFixture>
	{
		private readonly DalContextFixture _fixture;
		private readonly Quiz _simpleQuiz;

		public QuizCrudTests(DalContextFixture fixture)
		{
			_fixture = fixture;
			_simpleQuiz = new Quiz
			{
				Title = "Test Quiz",
				Description = "This is a simple test.",
				EventId = "1234"
			};
			
		}
		[Fact]
		public void TestCreateQuiz()
		{
			var blnSucceeded = false;
			string strExceptionMessage = string.Empty;
			int expectedId = 1;
			int actualId = 0;

			// Act
			try
			{
				using (var uow = _fixture.CreateUnitOfWork())
				{
					uow.QuizRepository.Create(_simpleQuiz);
					blnSucceeded = uow.Save();

					var quiz = uow.QuizRepository.GetById(expectedId);
					actualId = quiz.Id;
				}
				_fixture.Dispose();
			}
			catch (Exception ex)
			{
				blnSucceeded = false;
				strExceptionMessage = ex.Message;
				
			}

			//Assert
			Assert.True(blnSucceeded, strExceptionMessage);
			Assert.Equal(expectedId, actualId);
		}

		[Fact]
		public void TestUpdateQuiz()
		{
			var blnSucceeded = false;
			string strExceptionMessage = string.Empty;
			int expectedId = 1;
			int actualId = 0;
			string expectedEventId = "4321";
			string expectedTitle = "This is the Quiz One New Title";
			string actualEventId = string.Empty;
			string actualTitle = string.Empty;

			
			// Act
			try
			{
				using (var uow = _fixture.CreateUnitOfWork())
				{
					uow.QuizRepository.Create(_simpleQuiz);
					uow.Save();

					var quiz = uow.QuizRepository.Get(x => x.Id == expectedId).FirstOrDefault();
					
					quiz.Title = expectedTitle;
					quiz.EventId = "4321";
					uow.QuizRepository.Update(quiz);
					blnSucceeded = uow.Save();
					var updatedQuiz = uow.QuizRepository.GetFirst(x => x.Id == expectedId);
					actualId = updatedQuiz.Id;
					actualEventId = updatedQuiz.EventId;
					actualTitle = updatedQuiz.Title;

				}
				_fixture.Dispose();
			}
			catch (Exception ex)
			{
				blnSucceeded = false;
				strExceptionMessage = ex.Message;

			}

			//Assert
			Assert.True(blnSucceeded, strExceptionMessage);
			Assert.Equal(expectedId, actualId);
			Assert.Equal(expectedTitle, actualTitle);
			Assert.Equal(expectedEventId, actualEventId);
		}

		[Fact]
		public void TestDeleteQuizById()
		{
			var blnSucceeded = false;
			string strExceptionMessage = string.Empty;
			int expectedId = 1;
			int actualId = 0;
			Quiz actualDeletedRecord = _simpleQuiz; // Should return null in query after delete.

			// Act
			try
			{
				using (var uow = _fixture.CreateUnitOfWork())
				{
					uow.QuizRepository.Create(_simpleQuiz);
					uow.Save();

					var quiz = uow.QuizRepository.Get(x => x.Id == expectedId, null, "");
					actualId = quiz.FirstOrDefault().Id;

					uow.QuizRepository.Delete(actualId);
					blnSucceeded = uow.Save();
					actualDeletedRecord = uow.QuizRepository.GetFirst(x => x.Id == actualId);

					// Re-create the quiz as other test quizzes are failing.
					uow.QuizRepository.Create(_simpleQuiz);
					uow.Save();
					quiz = uow.QuizRepository.Get(x => x.Id == expectedId, null, "");
					actualId = quiz.FirstOrDefault().Id;

				}
				_fixture.Dispose();
			}
			catch (Exception ex)
			{
				blnSucceeded = false;
				strExceptionMessage = ex.Message;

			}

			//Assert
			Assert.True(blnSucceeded, strExceptionMessage);
			Assert.Equal(expectedId, actualId);
			Assert.Null(actualDeletedRecord);
		}

		
		[Fact]
		public void TestDeleteQuizByExpresion_ExpectNotImplemented()
		{
			var blnSucceeded = false;
			string strExceptionMessage = string.Empty;
			int expectedId = 1;
			int actualId = 0;
			bool exceptionThrown = false;
			string exceptionMsg = string.Empty;

			// Act
			try
			{
				using (var uow = _fixture.CreateUnitOfWork())
				{
					uow.QuizRepository.Create(_simpleQuiz);
					uow.Save();

					var quiz = uow.QuizRepository.Get(x => x.Id == expectedId, null, "");
					actualId = quiz.FirstOrDefault().Id;

					uow.QuizRepository.Delete(x => x.Id == actualId);
					blnSucceeded = uow.Save();

				}
				_fixture.Dispose();
			}
			catch (NotImplementedException niEx)
			{
				exceptionThrown = true;
				exceptionMsg = niEx.Message;

			}
			catch (Exception ex)
			{
				blnSucceeded = false;
				strExceptionMessage = ex.Message;

			}

			//Assert
			Assert.True(exceptionThrown, strExceptionMessage);
			Assert.False(blnSucceeded, strExceptionMessage);
			Assert.Equal(expectedId, actualId);
		}
	}
}