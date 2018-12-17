using Microsoft.EntityFrameworkCore;
using QuizApp.Data.Core.Interfaces;
using System;

namespace QuizApp.Data.Core.Common
{
	public class CrudRepository<T> : ReadOnlyRepository<T>, ICrud<T> where T : class
	{
		#region Private member variables.
		internal new DbContext _context;
		internal new DbSet<T> _dbSet;
		#endregion

		public CrudRepository(DbContext context): base(context)
		{
			_context = context;
			_dbSet = _context.Set<T>();
		}
		public virtual void Create(T entity)
		{
			_dbSet.Add(entity);
		}

		public virtual void Delete(Func<T, bool> where)
		{
			throw new NotImplementedException();
		}

		public virtual void Delete(object id)
		{
			T entityToDelete = _dbSet.Find(id);
			Delete(entityToDelete);
		}

		public virtual void Delete(T entityToDelete)
		{
			if (_context.Entry(entityToDelete).State == EntityState.Detached)
			{
				_dbSet.Attach(entityToDelete);
			}
			_dbSet.Remove(entityToDelete);
		}

		public virtual void Update(T entityToUpdate)
		{
			_dbSet.Attach(entityToUpdate);
			_context.Entry(entityToUpdate).State = EntityState.Modified;
		}
	}
}
