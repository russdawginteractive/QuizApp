using System;
using System.Linq.Expressions;

namespace QuizApp.Data.Core.Interfaces
{
	interface ICrud<T>: IReadOnly<T> where T: class
	{
		void Create(T entity);
		void Update(T entityToUpdate);
		void Delete(Expression<Func<T, bool>> where);
		void Delete(object id);

	}
}
