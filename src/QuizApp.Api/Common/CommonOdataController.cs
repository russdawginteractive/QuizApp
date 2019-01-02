using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuizApp.Api.Controllers;
using QuizApp.Api.Interface;
using QuizApp.Data.Core.Common;
using QuizApp.Data.Entities.Base;
using QuizApp.Data.Services.UnitOfWork;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Api.Common
{
	[Produces("application/json")]
	public partial class CommonOdataController<T> : ODataController, ICommonOdataController<T> where T : BaseModel
	{
		private readonly QuizAppUnitOfWork _uow;
		public CrudRepository<T> CrudRepository { get; set; }

		public CommonOdataController(QuizAppUnitOfWork unitOfWork)
		{
			_uow = unitOfWork;
			CrudRepository = null;
		}

		// GET: odata/T
		[EnableQuery]
		public IActionResult Get() => Ok(CrudRepository.GetAll());

		// GET: odata/T/[Id]
		[EnableQuery]
		public SingleResult<T> Get(int key)
		{
			IQueryable<T> result = CrudRepository.GetById(key);
			return SingleResult.Create(result);
		}

		[EnableQuery]
		public async Task<IActionResult> Post([FromBody]T entity)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			CrudRepository.Create(entity);
			try
			{
				await _uow.Save();
			}
			catch (DbUpdateException updEx)
			{
				if (updEx.InnerException != null)
				{
					return BadRequest(updEx.InnerException.Message);
				}
				return BadRequest(updEx.Message);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return Created(entity);
		}

		[EnableQuery]
		public async Task<IActionResult> Patch(int key, Delta<T> patch)
		{

			var entity = CrudRepository.GetFirst(x => x.Id == key);
			if (entity == null)
			{
				return NotFound();
			}

			patch.Patch(entity);

			try
			{
				await _uow.Save();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!KeyExists(key))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}
			catch (DbUpdateException Ex)
			{
				if (Ex.InnerException != null)
				{
					return BadRequest(Ex.InnerException.Message);
				}
				return BadRequest(Ex.Message);

			}
			catch
			{
				throw;
			}
			return Updated(entity);
		}
		public async Task<IActionResult> Delete([FromODataUri] int key)
		{
			var entity = CrudRepository.GetFirst(x => x.Id == key);
			if (entity == null)
			{
				return NotFound();
			}
			CrudRepository.Delete(entity.Id);
			await _uow.Save();
			return NoContent();
		}
		private bool KeyExists(int key)
		{
			return CrudRepository.GetAll().Any(x => x.Id == key);
		}
	}
}