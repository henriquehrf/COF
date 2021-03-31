using COF.Domain.ValueTypes;
using System.Collections.Generic;

namespace COF.Domain.Entities
{
	public class ContaBancaria : BaseEntity<int>
	{
		public ContaBancaria(Nome nome, Saldo saldoConta, int idBanco, int idConfiguracaoObjetivo)
		{
			Nome = nome;
			SaldoConta = saldoConta;
			IdBanco = idBanco;
			IdConfiguracaoObjetivo = idConfiguracaoObjetivo;
		}

		public Nome Nome { get; }
		public Saldo SaldoConta { get; }
		public int IdBanco { get; }
		public int IdConfiguracaoObjetivo { get; }

		public virtual Banco Banco { get; }
		public virtual ConfiguracaoObjetivo ConfiguracaoObjetivo { get; }

		public virtual ICollection<LancamentoContaBancaria> LancamentosContaObjetivo { get; } = new HashSet<LancamentoContaBancaria>();
	}
}
