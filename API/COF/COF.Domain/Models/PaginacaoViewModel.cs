using System;
using System.Collections.Generic;
using System.Linq;

namespace COF.Domain.Models
{
	public sealed class PaginacaoViewModel<TResult> where TResult : class
	{
		private const int TAMANHO_PADRAO = 25;

		public int TotalRegistros { get; private set; }
		public int TotalPaginas { get; private set; }
		public int TamanhoPagina { get; private set; }
		public int PaginaAtual { get; private set; }
		public int RegistrosNaPagina { get; private set; }
		public IList<TResult> Resultado { get; private set; }

		public static PaginacaoViewModel<TResult> From<TEntity>(IQueryable<TEntity> registros,
												Func<IList<TEntity>, IList<TResult>> objMapper,
												int paginaAtual = 1,
												int tamanhoPagina = TAMANHO_PADRAO)
		{
			if (paginaAtual <= 0)
				paginaAtual = 1;

			if (tamanhoPagina <= 0)
				tamanhoPagina = TAMANHO_PADRAO;

			int totalRegistros = registros.Count();
			int totalPagina = (int)Math.Ceiling(totalRegistros / (double)tamanhoPagina);
			var resultado = objMapper(registros.Skip(totalPagina > 0 ? tamanhoPagina * (paginaAtual - 1) : totalPagina).
							Take(tamanhoPagina).ToList());

			return new PaginacaoViewModel<TResult>
			{
				TotalRegistros = totalRegistros,
				TotalPaginas = totalPagina,
				TamanhoPagina = tamanhoPagina,
				PaginaAtual = paginaAtual,
				RegistrosNaPagina = resultado.Count(),
				Resultado = resultado
			};
		}
	}
}
