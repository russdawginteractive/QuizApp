using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Data.Core.Common;
using QuizApp.Data.Entities.Base;

namespace QuizApp.Api.Interface
{
	public interface ICommonOdataController<T> where T : BaseModel
	{
		CrudRepository<T> CrudRepository { get; set; }

		Task<IActionResult> Delete([FromODataUri] int key);
		IActionResult Get();
		SingleResult<T> Get(int key);
		Task<IActionResult> Patch(int key, Delta<T> patch);
		Task<IActionResult> Post([FromBody] T entity);
	}
}