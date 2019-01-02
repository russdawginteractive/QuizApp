using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizApp.Api.Common;
using QuizApp.Data.Entities.Base;
using QuizApp.Data.Services.UnitOfWork;
using QuizApp.UnitTest.XUnitTesting.Fixture;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace QuizApp.UnitTest.XUnitTesting.ApiTests.Common
{
	public abstract class OdataCrudTests<T> : IClassFixture<DalContextFixture> where T : BaseModel
	{
		private readonly DalContextFixture _fixture;
		public QuizAppUnitOfWork ODataTestUnitOfWork { get; set; }
		public CommonOdataController<T> ODataController { get; set; }

		public OdataCrudTests(DalContextFixture fixture)
		{
			_fixture = fixture;
			ODataTestUnitOfWork = _fixture.CreateUnitOfWork();
		}

		public virtual void SimplePostTest(T objectToPut)
		{

			// Act 
			var actionResponse = ODataController.Post(objectToPut);

			//Assert
			Assert.NotNull(actionResponse);
			Assert.Equal(TaskStatus.RanToCompletion, actionResponse.Status);
			Assert.IsType<CreatedODataResult<T>>(actionResponse.Result);

		}

		public virtual void SimplePostTest_ReturnsInvalidModelBadRequest(T objectToPut)
		{
			// Act 
			var badResponse = ODataController.Post(objectToPut);

			//Assert
			Assert.IsType<BadRequestObjectResult>(badResponse.Result);
			BadRequestObjectResult badRequestObject = badResponse.Result as BadRequestObjectResult;
			Assert.Contains("NOT NULL constraint failed", badRequestObject.Value.ToString());
		}

		public virtual void SimplePatchTest(int recordIdToUpdate, string propertyToUpdate, string properyToUpdateValue)
		{
			// Arrange
			SingleResult<T> singleResult = ODataController.Get(recordIdToUpdate);
			T recordToUpdate = singleResult.Queryable.FirstOrDefault();

			var deltaQuiz = new Delta<T>(typeof(T));
			deltaQuiz.TrySetPropertyValue(propertyToUpdate, properyToUpdateValue);


			// Act
			var actionResponse = ODataController.Patch(recordToUpdate.Id, deltaQuiz);
			var updatedRecord = ODataController.Get(recordIdToUpdate);

			// Assert
			Assert.NotNull(actionResponse);
			Assert.IsType<UpdatedODataResult<T>>(actionResponse.Result);
			// Check fields are the correct value.
			Assert.IsType<SingleResult<T>>(updatedRecord);
			T recordUpdated = updatedRecord.Queryable.FirstOrDefault();
			Type recordType = recordUpdated.GetType();
			PropertyInfo propertyUpdated = recordType.GetProperty(propertyToUpdate);
			var updatedValue = propertyUpdated.GetValue(recordUpdated);
			Assert.Equal(properyToUpdateValue, updatedValue.ToString());


		}

		public virtual void SimplePatchTest_ResultInvalidModelBadRequest(int recordIdToUpdate, string propertyToUpdate)
		{
			// Arrange
			// Arrange
			SingleResult<T> singleResult = ODataController.Get(recordIdToUpdate);
			T recordToUpdate = singleResult.Queryable.FirstOrDefault();

			var deltaQuiz = new Delta<T>(typeof(T));
			deltaQuiz.TrySetPropertyValue("Title", null);


			// Act
			var badResponse = ODataController.Patch(recordToUpdate.Id, deltaQuiz);

			// Assert
			Assert.IsType<BadRequestObjectResult>(badResponse.Result);

		}

		public void SimpleDeleteTestAsync(T objectToDelete)
		{
			//// Act 
			var actionCreate = ODataController.Post(objectToDelete);
			Assert.NotNull(actionCreate);
			Assert.Equal(TaskStatus.RanToCompletion, actionCreate.Status);
			
			var actionGetAll = ODataController.Get() as OkObjectResult;
			Assert.IsAssignableFrom<DbSet<T>>(actionGetAll.Value);
			var allRecords = actionGetAll.Value as DbSet<T>;
			Assert.NotNull(allRecords);
			var lastQuizAdded = allRecords.LastOrDefault();
			
			
			var result = ODataController.Delete(lastQuizAdded.Id);

			// Final Assert
			Assert.NotNull(result);
			var noContentResult = result.Result as NoContentResult;
			Assert.Equal(204, noContentResult.StatusCode);
		}
	}
}
