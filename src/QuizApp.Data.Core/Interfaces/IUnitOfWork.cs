using System;

namespace QuizApp.Data.Core.Interfaces
{
	public interface IUnitOfWork: IDisposable
	{
		/// <summary>
		/// Save method.
		/// </summary>
		bool Save();
	}
}
