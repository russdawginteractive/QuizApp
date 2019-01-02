using Microsoft.AspNetCore.Mvc;
using QuizApp.Api.Common;
using QuizApp.Data.Entities.Models;
using QuizApp.Data.Services.UnitOfWork;

namespace QuizApp.Api.Controllers
{
	[Produces("application/json")]
	public class QuizController : CommonOdataController<Quiz>
	{
		//private readonly QuizAppUnitOfWork _uow;

		public QuizController(QuizAppUnitOfWork unitOfWork) : base(unitOfWork)
		{
			CrudRepository = unitOfWork.QuizRepository;
		}

		//// GET: odata/Quiz
		//[EnableQuery]
		//public IActionResult Get() => Ok(_uow.QuizRepository.GetAll());

		//// GET: odata/Quiz/[Id]
		//[EnableQuery]
		//public SingleResult<Quiz> Get(int key)
		//{
		//	IQueryable<Quiz> result = _uow.QuizRepository.GetById(key);
		//	return SingleResult.Create(result);
		//}

		//[EnableQuery]
		//public async Task<IActionResult> Post([FromBody]Quiz quiz)
		//{
		//	if (!ModelState.IsValid)
		//	{
		//		return BadRequest(ModelState);
		//	}
		//	_uow.QuizRepository.Create(quiz);
		//	try
		//	{
		//		await _uow.Save();
		//	}
		//	catch(Exception ex)
		//	{
		//		throw ex;
		//	}
		//	return Created(quiz);
		//}

		//[EnableQuery]
		//public async Task<IActionResult> Patch(int key, Delta<Quiz> patch)
		//{

		//	var entity = _uow.QuizRepository.GetFirst(x => x.Id == key);
		//	if (entity == null)
		//	{
		//		return NotFound();
		//	}

		//	patch.Patch(entity);

		//	try
		//	{
		//		await _uow.Save();
		//	}
		//	catch (DbUpdateConcurrencyException)
		//	{
		//		if (!QuizExists(key))
		//		{
		//			return NotFound();
		//		}
		//		else
		//		{
		//			throw;
		//		}
		//	}
		//	catch (DbUpdateException dbuEx)
		//	{
		//		if (dbuEx.InnerException != null)
		//		{
		//			return BadRequest(dbuEx.InnerException.Message);
		//		}
		//		return BadRequest(dbuEx.Message);

		//	}
		//	catch
		//	{
		//		throw;
		//	}
		//	return Updated(entity);
		//}

		//public async Task<IActionResult> Delete([FromODataUri] int key)
		//{
		//	var entity = _uow.QuizRepository.GetFirst(x => x.Id == key);
		//	if (entity == null)
		//	{
		//		return NotFound();
		//	}
		//	_uow.QuizRepository.Delete(entity.Id);
		//	await _uow.Save();
		//	return NoContent();
		//}
		//private bool QuizExists(int key)
		//{
		//	return _uow.QuizRepository.GetAll().Any(x => x.Id == key);
		//}

	}
}