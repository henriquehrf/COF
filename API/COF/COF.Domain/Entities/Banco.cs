using COF.Domain.ValueTypes;
using System;
using System.Collections.Generic;

namespace COF.Domain.Entities
{
	public class Banco : BaseEntity<int>
	{
		public Banco(Nome nome, int codigo, Guid guidLogo)
		{
			Nome = nome;
			Codigo = codigo;
			GuidLogo = guidLogo;
		}

		public Nome Nome { get; }
		public int Codigo { get; }
		public Guid GuidLogo { get; }

		public virtual ICollection<ContaBancaria> ContasBancarias { get; } = new HashSet<ContaBancaria>();

	}
}
