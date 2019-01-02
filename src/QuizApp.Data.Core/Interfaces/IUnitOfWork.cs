using System;
using System.Threading.Tasks;

namespace QuizApp.Data.Core.Interfaces
{
	public interface IUnitOfWork: IDisposable
	{
		/// <summary>
		/// Save method.
		/// </summary>
		Task<bool> Save();

	}
}
