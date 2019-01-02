using QuizApp.Api.Controllers;
using QuizApp.Data.Entities.Models;
using QuizApp.UnitTest.XUnitTesting.ApiTests.Common;
using QuizApp.UnitTest.XUnitTesting.Fixture;
using System.Collections.Generic;
using Xunit;

namespace QuizApp.UnitTest.XUnitTesting.ApiTests
{
	public class QuizApiCrudTests : OdataCrudTests<Quiz>
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
						EventId = "3421",
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
				new object[] {1, "Title", "Patch Test Quiz Update"},
				new object[] {1, "Description", "This is the question one update description"},
				new object[] {1, "EventId", "4321"}
			};
		public static IEnumerable<object[]> BadPatchData =>
			new List<object[]>
			{
					new object[] {1, "Title"},
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

		public QuizApiCrudTests(DalContextFixture fixture) : base(fixture)
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
		public void QuizSimplePatchTests(int recordIdToUpdate, string propertyToUpdate, string properyToUpdateValue)
		{
			SimplePatchTest(recordIdToUpdate, propertyToUpdate, properyToUpdateValue);
		}
		[Theory]
		[MemberData(nameof(BadPatchData))]
		public void QuizSimplePatchTests_ResultInvalidModelBadReques(int recordIdToUpdate, string propertyToUpdate)
		{
			SimplePatchTest_ResultInvalidModelBadRequest(recordIdToUpdate, propertyToUpdate);
		}

		[Theory]
		[MemberData(nameof(QuizToDelete))]
		public void QuizSimpleDeleteTest(Quiz quiz)
		{
			SimpleDeleteTestAsync(quiz);
		}

	}
}
