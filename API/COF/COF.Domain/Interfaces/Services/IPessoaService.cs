using COF.Domain.Entities;

namespace COF.Domain.Interfaces.Services
{
	public interface IPessoaService
	{
		Pessoa InserirPessoa(Pessoa pessoa);

		Pessoa AlterarPessoa(Pessoa pessoa);

		Pessoa ExcluirPessoa(int id);
	}
}
