using COF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace COF.Service.Test.Mocks
{
	public abstract class BaseMock<T, K>
	{
		public abstract IList<T> MassaDeDados { get; }
		private static IList<T> _massaDeDadosSaida;
		private static IList<T> MassaDeDadosSaida
		{
			get
			{
				if (_massaDeDadosSaida == null)
					_massaDeDadosSaida = ObterDados();
				return _massaDeDadosSaida;
			}
		}
			public static T ById(int id) => MassaDeDadosSaida.SingleOrDefault(p => (p as BaseEntity<int>).Id.Equals(id));
		public static IQueryable<T> Filter(Expression<Func<T, bool>> predicate) => MassaDeDadosSaida.AsQueryable().Where(predicate);

		private static IList<T> ObterDados()
		{
			if (Activator.CreateInstance<K>() is BaseMock<T, K> t)
				return t.MassaDeDados;

			return default;
		}
	}
}
