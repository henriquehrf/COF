using COF.Domain.Entities;
using COF.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace COF.Infra.Data.Repository
{
	public class BaseRepository<T, K> where T : BaseEntity<K>
	{
		protected readonly COFContext _cofContext;

		public BaseRepository(COFContext COFContext)
		{
			_cofContext = COFContext;
		}

		public virtual T Inserir(T obj)
		{
			_cofContext.Add(obj);
			return obj;
		}

		public virtual T Alterar(T obj)
		{
			_cofContext.Update(obj);
			return obj;
		}

		public virtual T Excluir(int id)
		{
			var obj = ById(id);
			if(obj != null)
				_cofContext.Remove(obj);

			return obj;
		}

		public async virtual Task<IList<T>> Todos()
		{
			var result = await _cofContext.Set<T>().ToListAsync();
			foreach (var obj in result.AsParallel())
				_cofContext.Entry(obj).State = EntityState.Detached;
			return result;

		}

		public async virtual Task<IList<T>> FilterAsync(Expression<Func<T, bool>> predicate)
		{
			var result = await _cofContext.Set<T>().Where(predicate).ToListAsync();
			foreach (var obj in result.AsParallel())
				_cofContext.Entry(obj).State = EntityState.Detached;
			return result;

		}

		public virtual T ById(int id)
		{
			var obj = _cofContext.Set<T>().Find(id);
			if (obj != null)
				_cofContext.Entry<T>(obj).State = EntityState.Detached;

			return obj;
		}

	}
}
