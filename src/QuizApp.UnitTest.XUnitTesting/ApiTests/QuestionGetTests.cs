using QuizApp.Api.Common;
using QuizApp.Api.Controllers;
using QuizApp.Api.Interface;
using QuizApp.Data.Entities.Models;
using QuizApp.UnitTest.XUnitTesting.ApiTests.Common;
using QuizApp.UnitTest.XUnitTesting.Fixture;
using Xunit;

namespace QuizApp.UnitTest.XUnitTesting.ApiTests
{
	public class QuestionGetTests : ODataGetTests<Question>
	{
		public QuestionGetTests(DalContextFixture fixture):base(fixture)
		{
			ODataController = new QuestionController(ODataTestUnitOfWork);
		}
	}
}
