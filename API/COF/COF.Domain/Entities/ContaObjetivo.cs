using COF.Domain.ValueTypes;
using System;
using System.Collections.Generic;

namespace COF.Domain.Entities
{
	public class ContaObjetivo : BaseEntity<int>
	{
		public ContaObjetivo(string descricao, 
							Saldo saldoConta, 
							int idConfiguracaoObjetivo, 
							Saldo limiteObjetivo, 
							bool ativo, 
							byte grauImportancia, 
							bool ehContaTemporaria, 
							DateTime? dataHoraAlcance)
		{
			Descricao = descricao;
			SaldoConta = saldoConta;
			IdConfiguracaoObjetivo = idConfiguracaoObjetivo;
			LimiteObjetivo = limiteObjetivo;
			Ativo = ativo;
			GrauImportancia = grauImportancia;
			EhContaTemporaria = ehContaTemporaria;
			DataHoraAlcance = dataHoraAlcance;
		}

		public string Descricao { get; }
		public Saldo SaldoConta { get; }
		public int IdConfiguracaoObjetivo { get; }
		public Saldo LimiteObjetivo { get; }
		public bool Ativo { get; }
		public byte GrauImportancia { get; }
		public bool EhContaTemporaria { get; }
		public DateTime? DataHoraAlcance { get; }

		public ConfiguracaoObjetivo Objetivo { get; }

		public virtual ICollection<LancamentoContaObjetivo> LancamentosContaObjetivo { get; } = new HashSet<LancamentoContaObjetivo>();

	}
}
