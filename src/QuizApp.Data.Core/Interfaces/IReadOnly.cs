using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace QuizApp.Data.Core.Interfaces
{
	public interface IReadOnly<T> where T: class
	{
		T GetById(object id);
		IEnumerable<T> GetAll();
		IEnumerable<T> Get(Expression<Func<T, bool>> filter);
		IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
		IQueryable<T> GetQueryable(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null, int? skip = null, int? take = null);
		T GetFirst(Expression<Func<T, bool>> filter);
		IQueryable<T> GetDataBySqlCommand(string sql, params object[] parameters);

	}
}
