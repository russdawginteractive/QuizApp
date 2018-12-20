using Microsoft.Extensions.DependencyInjection;
using QuizApp.Data.Dal;
using QuizApp.UnitTest.XUnitTesting.Fixture;
using System;
using System.Linq;
using Xunit;

namespace QuizApp.UnitTest.XUnitTesting.Database
{
	public class FixtureTests:IClassFixture<DalContextFixture>
	{
		private readonly DalContextFixture _fixture;

		public FixtureTests(DalContextFixture fixture)
		{
			_fixture = fixture;
		}
	
		[Fact]
		public void TestSqlLiteUnitOfWorkFixture()
		{
			int expectedCount = 2;
			int actualCount = 0;

			using (var uow = _fixture.CreateUnitOfWork())
			{
				actualCount = uow.UserReadOnlyRepository.GetAll().Count();
			}

			Assert.Equal(expectedCount, actualCount);
		}
	}

}
