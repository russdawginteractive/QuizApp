using AutoMapper;
using QuizApp.Data.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Evenflo.Demandware.DataCore.Static
{
	public static class ReadOnlyRetriever<S, D> where S: class where D: class
	{
		public static D GetById(ReadOnlyRepository<S> repo, object id)
		{
			IQueryable<S> item = repo.GetById(id);
			S firstItem = item.FirstOrDefault();
			if (firstItem != null)
			{
				
				var model = Mapper.Map<S, D>(firstItem);
				return model;
			}
			return null;
		}
		public static IEnumerable<D> GetAll(ReadOnlyRepository<S> repo)
		{
			var items = repo.GetAll().ToList();
			if (items.Any())
			{
				var model = Mapper.Map<List<S>, List<D>>(items);
				return model;
			}
			return null;

		}

		public static IEnumerable<D> Get(Expression<Func<S, bool>> where, ReadOnlyRepository<S> repo)
		{
			var items = repo.Get(where).ToList();
			if (items.Any())
			{
				var model = Mapper.Map<List<S>, List<D>>(items);
				return model;
			}
			return null;

		}
	}
}
