using COF.Domain.Entities;

namespace COF.Domain.Interfaces.Services
{
	public interface IPessoaService
	{
		Pessoa InserirPessoa(Pessoa pessoa);

		void AlterarPessoa(Pessoa pessoa);

		void ExcluirPessoa(int id);
	}
}
