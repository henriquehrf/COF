using COF.Domain.Entities;
using COF.Domain.Interfaces.Repository;
using COF.Domain.Interfaces.Services;
using COF.Infra.Shared.NotificationContext;
using System.Linq;

namespace COF.Service.Service
{
	public class PessoaService : IPessoaService
	{
		private readonly IPessoaRepository _pessoaRepository;
		private readonly NotificationContext _notificationContext;

		public PessoaService(IPessoaRepository pessoaRepository, NotificationContext notificationContext)
		{
			_pessoaRepository = pessoaRepository;
			_notificationContext = notificationContext;
		}

		public Pessoa InserirPessoa(Pessoa pessoa)
		{
			_notificationContext.AddNotifications(pessoa.Notifications);

			ValidarCadastro(pessoa);

			if (_notificationContext.Valid)
				return _pessoaRepository.Inserir(pessoa);

			return pessoa;
		}

		public void AlterarPessoa(Pessoa pessoa)
		{
			_notificationContext.AddNotifications(pessoa.Notifications);

			ValidarCadastro(pessoa);

			if (_notificationContext.Valid)
				_pessoaRepository.Alterar(pessoa);
		}

		public void ExcluirPessoa(int id)
		{
			var pessoa = _pessoaRepository.Excluir(id);
			if (pessoa == null)
				_notificationContext.AddNotification("Id", "O Id informado não corresponde a nenhuma pessoa.");

		}

		private void ValidarCadastro(Pessoa pessoa)
		{
			if ((_pessoaRepository.Filter(p => (p.Cpf.Equals(pessoa.Cpf) && p.Id != pessoa.Id))).Any())
				_notificationContext.AddNotification("Cpf", $"O CPF {pessoa.Cpf} já está cadastrado a uma pessoa.");

			if ((_pessoaRepository.Filter(p => (p.Usuario.Equals(pessoa.Usuario) && p.Id != pessoa.Id))).Any())
				_notificationContext.AddNotification("Usuario", $"O Usuário {pessoa.Usuario} já está cadastrado a uma pessoa.");

			if ((pessoa.Id) > 0 && (_pessoaRepository.ById(pessoa.Id) == null))
				_notificationContext.AddNotification("Id", $"O Id {pessoa.Id} não corresponde a uma pessoa cadastrada.");

		}
	}
}
