using COF.Domain.ValueTypes;
using System;

namespace COF.Domain.Entities
{
	public class LancamentoContaBancaria : BaseEntity<int>
	{
		public LancamentoContaBancaria(int idContaCorrente,
									  string descricao, 
									  DateTime dataHoraLancamento, 
									  Saldo valorLancamento, 
									  char tipoOperacao, 
									  Guid? guidComprovante)
		{
			IdContaCorrente = idContaCorrente;
			Descricao = descricao;
			DataHoraLancamento = dataHoraLancamento;
			ValorLancamento = valorLancamento;
			TipoOperacao = tipoOperacao;
			GuidComprovante = guidComprovante;
		}

		public int IdContaCorrente { get; }
		public string Descricao { get; }
		public DateTime DataHoraLancamento { get; }
		public Saldo ValorLancamento { get; }
		public char TipoOperacao { get; }
		public Guid? GuidComprovante { get; }

		public virtual ContaBancaria ContaBancaria { get; }
	}
}
