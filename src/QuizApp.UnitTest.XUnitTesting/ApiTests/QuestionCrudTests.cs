using QuizApp.Api.Controllers;
using QuizApp.Data.Entities.Models;
using QuizApp.UnitTest.XUnitTesting.ApiTests.Common;
using QuizApp.UnitTest.XUnitTesting.Fixture;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace QuizApp.UnitTest.XUnitTesting.ApiTests
{
	public class QuestionCrudTests : OdataCrudTests<Question>
	{
		public static IEnumerable<object[]> GoodData =>
			new List<Question[]>
			{
				new Question[]
				{
					new Question
					{
						Title = "This is Question Two"
					}
				}
			};
		public static IEnumerable<object[]> BadData =>
			new List<Question[]>
			{
				new Question[]
				{
					new Question
					{
						QuizId = 1
					}
				}
			};
		public static IEnumerable<object[]> GoodPatchData =>
			new List<object[]>
			{
				new object[] {1, "Title", "Question One PATCHED!"},
			};

		public static IEnumerable<object[]> BadPatchData =>
			new List<object[]>
			{
				new object[] {1, "Title"},
			};

		public static IEnumerable<object[]> QuestionToDelete =>
			new List<Question[]>
			{
				new Question[]
				{
						new Question
						{
							Title = "For Delete",
							QuizId = 1
						}
				}
			};
		public QuestionCrudTests(DalContextFixture fixture) : base(fixture)
		{
			ODataController = new QuestionController(ODataTestUnitOfWork);
		}

		[Theory]
		[MemberData(nameof(GoodData))]
		public void QuestionSimplePostTest(Question question)
		{
			question.QuizId = 1;

			SimplePostTest(question);
		}

		[Theory]
		[MemberData(nameof(GoodData))]
		public void QuestionPostTest_WithQuizReference(Question question)
		{
			var quiz = ODataTestUnitOfWork.QuizRepository.GetFirst(x => x.Id == 1);

			question.Quiz = quiz;
			question.CorrectAnswer = quiz.Questions.FirstOrDefault().Answers.LastOrDefault();
			SimplePostTest(question);
		}

		//[Theory]
		//[MemberData(nameof(GoodData))]
		//public void QuestionPostTest_WithQuizReference_AndCorrectAnswer(Question question)
		//{
		//	var quiz = ODataTestUnitOfWork.QuizRepository.GetFirst(x => x.Id == 1);

		//	question.Quiz = quiz;
		//	question.CorrectAnswer = question.Answers.LastOrDefault();
		//	SimplePostTest(question);
		//}

		[Theory]
		[MemberData(nameof(GoodData))]
		public void QuestionSimplePostTest_ReturnsInvalidForiegnKeyBadRequest(Question question)
		{
			SimplePostTest_ReturnsInvalidForeignKeyBadRequest(question);
		}

		[Theory, MemberData(nameof(BadData))]
		public void QuestionSimplePostTest_ReturnsInvalidModelBadRequest(Question question)
		{
			SimplePostTest_ReturnsInvalidModelBadRequest(question);
		}

		[Theory, MemberData(nameof(GoodPatchData))]
		public void QuestionSimplePatchTest(int recordIdToUpdate, string propertyToUpdate, string propertyToUpdateValue)
		{
			SimplePatchTest(recordIdToUpdate, propertyToUpdate, propertyToUpdateValue);
		}

		[Theory]
		[MemberData(nameof(BadPatchData))]
		public void QuestionSimplePatchTests_ResultInvalidModelBadRequest(int recordIdToUpdate, string propertyToUpdate)
		{
			SimplePatchTest_ResultInvalidModelBadRequest(recordIdToUpdate, propertyToUpdate);
		}


		[Theory]
		[MemberData(nameof(QuestionToDelete))]
		public void QuestionSimpleDeleteTest(Question question)
		{
			SimpleDeleteTestAsync(question);
		}
	}
}
