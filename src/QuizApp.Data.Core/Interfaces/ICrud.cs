using System;

namespace QuizApp.Data.Core.Interfaces
{
	interface ICrud<T>: IReadOnly<T> where T: class
	{
		void Create(T entity);
		void Update(T entityToUpdate);
		void Delete(Func<T, bool> where);
		void Delete(object id);
		void Delete(T entityToDelete);

	}
}
