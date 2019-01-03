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
	public class QuizCrudTests : OdataCrudTests<Quiz>
	{
		public static IEnumerable<object[]> GoodData =>
			new List<Quiz[]>
			{
				new Quiz[]
				{
					new Quiz
					{
						Title = "Unit Test Quiz",
						Description = "This is a simple Unit Test Quiz",
						EventId = new Guid().ToString(),
						PathToQuizReference = "http://youtube.com"
					}
				}
			};
		public static IEnumerable<object[]> BadData =>
			new List<Quiz[]>
			{
				new Quiz[]
				{
					new Quiz
					{
						Description = "This is a simple Unit Test Quiz",
					}
				}
			};
		public static IEnumerable<object[]> GoodPatchData =>
			new List<object[]>
			{
				new object[] {0, "Title", "Patch Test Quiz Update"},
				new object[] {0, "Description", "This is the question one update description"},
				new object[] {0, "EventId", new Guid().ToString()}
			};
		public static IEnumerable<object[]> BadPatchData =>
			new List<object[]>
			{
					new object[] {0, "Title"},
			};

		public static IEnumerable<object[]> QuizToDelete =>
			new List<Quiz[]>
			{
				new Quiz[]
				{
						new Quiz
						{
							Title = "For Delete",
							Description = "For Delete",
							EventId = "XXXXXX"
						}
				}
			};

		public QuizCrudTests(DalContextFixture fixture) : base(fixture)
		{

			ODataController = new QuizController(ODataTestUnitOfWork);
		}
		[Theory]
		[MemberData(nameof(GoodData))]
		public void QuizSimplePostTest(Quiz quiz)
		{
			SimplePostTest(quiz);

		}

		[Theory]
		[MemberData(nameof(BadData))]
		public void QuizSimplePostTest_ReturnsInvalidModelBadRequest(Quiz quiz)
		{
			SimplePostTest_ReturnsInvalidModelBadRequest(quiz);
		}

		[Theory]
		[MemberData(nameof(GoodPatchData))]
		public void QuizSimplePatchTests(int idToUpdate, string propertyToUpdate, string propertyToUpdateValue)
		{
			Quiz lastQuiz = ODataTestUnitOfWork.QuizRepository.Get().LastOrDefault();
			SimplePatchTest(lastQuiz.Id, propertyToUpdate, propertyToUpdateValue);
		}
		[Theory]
		[MemberData(nameof(BadPatchData))]
		public void QuizSimplePatchTests_ResultInvalidModelBadReques(int idToUpdate, string propertyToUpdate)
		{
			Quiz lastQuiz = ODataTestUnitOfWork.QuizRepository.Get().LastOrDefault();
			SimplePatchTest_ResultInvalidModelBadRequest(lastQuiz.Id, propertyToUpdate);
		}

		[Theory]
		[MemberData(nameof(QuizToDelete))]
		public void QuizSimpleDeleteTest(Quiz quiz)
		{
			SimpleDeleteTestAsync(quiz);
		}

	}
}
