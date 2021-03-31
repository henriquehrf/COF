using System.Collections.Generic;

namespace COF.Domain.Entities
{
	public class PermissaoPessoa : BaseEntity<int>
	{
		public PermissaoPessoa(string descricao)
		{
			Descricao = descricao;
		}

		public string Descricao { get; set; }

		public virtual ICollection<ConfiguracaoObjetivo> ConfiguracaoObjetivos { get; } = new HashSet<ConfiguracaoObjetivo>();

	}
}
