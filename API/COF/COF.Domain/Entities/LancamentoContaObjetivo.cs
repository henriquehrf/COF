using COF.Domain.ValueTypes;
using System;

namespace COF.Domain.Entities
{
	public class LancamentoContaObjetivo : BaseEntity<int>
	{
		public LancamentoContaObjetivo(int idContaObjetivo, 
										Saldo valorLancamento, 
										DateTime dataHoraOperacao, 
										char tipoOperacao, 
										string observacao)
		{
			IdContaObjetivo = idContaObjetivo;
			ValorLancamento = valorLancamento;
			DataHoraOperacao = dataHoraOperacao;
			TipoOperacao = tipoOperacao;
			Observacao = observacao;
		}

		public int IdContaObjetivo { get; }
		public Saldo ValorLancamento { get; }
		public DateTime DataHoraOperacao { get; }
		public char TipoOperacao { get; }
		public string Observacao { get; }

		public ContaObjetivo ContaObjetivo { get; }

	}
}
