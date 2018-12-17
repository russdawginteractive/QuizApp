using Microsoft.EntityFrameworkCore;
using QuizApp.Data.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace QuizApp.Data.Core.Common
{
	public class ReadOnlyRepository<T> : IReadOnly<T> where T : class
	{
		#region Private member variables.
		internal DbContext _context;
		internal DbSet<T> _dbSet;
		#endregion

		public ReadOnlyRepository(DbContext context)
		{
			_context = context;
			_dbSet = context.Set<T>();
		}

		public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter)
		{
			IQueryable<T> query = _dbSet;
			query = query.Where(filter);
			return query.ToList();
		}

		public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
		{
			IQueryable<T> query = _dbSet;

			if (filter != null)
			{
				query = query.Where(filter);
			}

			foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			{
				query.Include(includeProperty);
			}

			if (orderBy != null)
			{
				return orderBy(query).ToList();
			}
			else
			{
				return query.ToList();
			}
		}

		public virtual IEnumerable<T> GetAll()
		{
			return _dbSet.ToList();
		}
		public virtual T GetFirst(Expression<Func<T, bool>> filter)
		{
			return Get(filter).FirstOrDefault();
		}
		public virtual T GetById(object id)
		{
			return _dbSet.Find(id);
		}

		public virtual IQueryable<T> GetDataBySqlCommand(string sql, params object[] parameters)
		{
			return _dbSet.FromSql(sql, parameters).AsQueryable();
		}

		public virtual IQueryable<T> GetQueryable(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string includeProperties, int? skip, int? take)
		{
			includeProperties = includeProperties ?? string.Empty;
			IQueryable<T> query = _dbSet;

			if (filter != null)
			{
				query = query.Where(filter);
			}

			foreach (var includeProperty in includeProperties.Split
				(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
			{
				query = query.Include(includeProperty);
			}

			if (orderBy != null)
			{
				query = orderBy(query);
			}

			if (skip.HasValue)
			{
				query = query.Skip(skip.Value);
			}

			if (take.HasValue)
			{
				query = query.Take(take.Value);
			}

			return query;
		}
	}
}
