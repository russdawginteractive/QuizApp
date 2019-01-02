using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizApp.Api.Common;
using QuizApp.Api.Interface;
using QuizApp.Data.Entities.Base;
using QuizApp.Data.Services.UnitOfWork;
using QuizApp.UnitTest.XUnitTesting.Fixture;
using System.Linq;
using Xunit;

namespace QuizApp.UnitTest.XUnitTesting.ApiTests.Common
{
	public abstract class ODataGetTests<T>: IClassFixture<DalContextFixture> where T: BaseModel
	{
		private readonly DalContextFixture _fixture;
		public QuizAppUnitOfWork ODataTestUnitOfWork { get; set; }
		public CommonOdataController<T> ODataController { get; set; }

		public ODataGetTests(DalContextFixture fixture)
		{
			_fixture = fixture;
			ODataTestUnitOfWork = _fixture.CreateUnitOfWork();
		}

		[Fact]
		public virtual void GetTest()
		{
			// Act 
			var result = ODataController.Get() as OkObjectResult;

			// Assert
			Assert.Equal(200, result.StatusCode);
			Assert.IsAssignableFrom<DbSet<T>>(result.Value);
			var obj = result.Value as DbSet<T>;
			Assert.NotNull(obj);
			Assert.Equal(1, obj.FirstOrDefault().Id);
		}

		[Fact]
		public virtual void GetWithIdTest()
		{
			// Act
			var result = ODataController.Get(1);

			//Assert
			Assert.IsType<SingleResult<T>>(result);
			Assert.True(result.Queryable.FirstOrDefault().Id == 1);
		}

		[Fact]
		public virtual void GetWithIdTest_Failure()
		{
			// Act
			var result = ODataController.Get(99);

			//Assert
			Assert.IsType<SingleResult<T>>(result);
			var resultSet = result.Queryable as IQueryable<T>;
			Assert.True(resultSet.FirstOrDefault() == null);

		}
	}
}
