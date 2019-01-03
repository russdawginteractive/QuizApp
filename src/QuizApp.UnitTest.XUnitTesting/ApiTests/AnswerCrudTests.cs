using QuizApp.Api.Controllers;
using QuizApp.Data.Entities.Models;
using QuizApp.UnitTest.XUnitTesting.ApiTests.Common;
using QuizApp.UnitTest.XUnitTesting.Fixture;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace QuizApp.UnitTest.XUnitTesting.ApiTests
{
	public class AnswerCrudTests : OdataCrudTests<Answer>
	{
		private Question _questionToAddAnswers = new Question
		{
			Title = "This is the Question From Answer CRUD TESTS",
			QuizId = 1,
		};
		private static int _addedQuestionId = 1; 

		public static IEnumerable<object[]> GoodData =>
			new List<Answer[]>
			{
				new Answer[]
				{
					new Answer
					{
						Choice = "This Answer is TRUE",
						Explanation = "This is the CORRECT ANSWER"
					}
				}
			};
		public static IEnumerable<object[]> BadData =>
			new List<Answer[]>
			{
				new Answer[]
				{
					new Answer
					{
					}
				}
			};
		public static IEnumerable<object[]> GoodPatchData =>
			new List<object[]>
			{
				new object[] {_addedQuestionId, "Choice", "CHOICE PATCHED!"},
			};

		public static IEnumerable<object[]> BadPatchData =>
			new List<object[]>
			{
				new object[] { _addedQuestionId, "Choice"},
			};

		public static IEnumerable<object[]> AnswerToDelete =>
			new List<Answer[]>
			{
				new Answer[]
				{
						new Answer
						{
							Choice = "Choice For Delete",
							QuestionId = 1
						}
				}
			};
		public AnswerCrudTests(DalContextFixture fixture) : base(fixture)
		{
			ODataController = new AnswerController(ODataTestUnitOfWork);
			ODataTestUnitOfWork.QuestionRepository.Create(_questionToAddAnswers);
			_addedQuestionId = ODataTestUnitOfWork.QuestionRepository.GetAll().LastOrDefault().Id;
		}

		[Theory]
		[MemberData(nameof(GoodData))]
		public void AnswerSimplePostTest(Answer answer)
		{
			answer.QuestionId = _addedQuestionId;

			SimplePostTest(answer);
		}

		[Theory]
		[MemberData(nameof(GoodData))]
		public void AnswerPostTest_WithQuizReference(Answer answer)
		{
			var question = ODataTestUnitOfWork.QuestionRepository.GetFirst(x => x.Id == _addedQuestionId);

			answer.Question = question;

			SimplePostTest(answer);
		}

		[Theory]
		[MemberData(nameof(GoodData))]
		public void AnswerSimplePostTest_ReturnsInvalidForiegnKeyBadRequest(Answer answer)
		{
			SimplePostTest_ReturnsInvalidForeignKeyBadRequest(answer);
		}

		[Theory, MemberData(nameof(BadData))]
		public void AnswerSimplePostTest_ReturnsInvalidModelBadRequest(Answer answer)
		{
			SimplePostTest_ReturnsInvalidModelBadRequest(answer);
		}

		[Theory, MemberData(nameof(GoodPatchData))]
		public void AnswerSimplePatchTest(int recordIdToUpdate, string propertyToUpdate, string propertyToUpdateValue)
		{
			SimplePatchTest(recordIdToUpdate, propertyToUpdate, propertyToUpdateValue);
		}

		[Theory]
		[MemberData(nameof(BadPatchData))]
		public void AnswerSimplePatchTests_ResultInvalidModelBadRequest(int recordIdToUpdate, string propertyToUpdate)
		{
			SimplePatchTest_ResultInvalidModelBadRequest(recordIdToUpdate, propertyToUpdate);
		}


		[Theory]
		[MemberData(nameof(AnswerToDelete))]
		public void AnswerSimpleDeleteTest(Answer answer)
		{
			SimpleDeleteTestAsync(answer);
		}
	}
}
