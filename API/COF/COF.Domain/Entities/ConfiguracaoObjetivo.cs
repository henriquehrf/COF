using System.Collections.Generic;

namespace COF.Domain.Entities
{
	public class ConfiguracaoObjetivo : BaseEntity<int>
	{
		public ConfiguracaoObjetivo(int idPessoa, int idPermissaoPessoa, bool ehProprietario)
		{
			IdPessoa = idPessoa;
			IdPermissaoPessoa = idPermissaoPessoa;
			EhProprietario = ehProprietario;
		}

		public int IdPessoa { get; }
		public int IdPermissaoPessoa { get; }
		public bool EhProprietario { get; }
		public virtual PermissaoPessoa PermissaoPessoa { get; }
		public virtual Pessoa Pessoa { get; }

		public virtual ICollection<ContaObjetivo> ConfiguracaoObjetivos { get; } = new HashSet<ContaObjetivo>();

	}
}
