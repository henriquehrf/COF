using COF.Domain.Entities;
using COF.Domain.Interfaces.Repository;
using COF.Domain.Interfaces.Services;
using COF.Infra.Shared.NotificationContext;
using COF.Service.Validators;

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
			_notificationContext.AddNotificationOrDefault(new CpfValidator(_pessoaRepository, pessoa).Validar());
			_notificationContext.AddNotificationOrDefault(new UniqueUsuarioValidator(_pessoaRepository, pessoa).Validar());


			if (_notificationContext.Valid)
				return _pessoaRepository.Inserir(pessoa);

			return pessoa;
		}

		public void AlterarPessoa(Pessoa pessoa)
		{
			_notificationContext.AddNotifications(pessoa.Notifications);
			_notificationContext.AddNotificationOrDefault(new CpfValidator(_pessoaRepository, pessoa).Validar());
			_notificationContext.AddNotificationOrDefault(new UniqueUsuarioValidator(_pessoaRepository, pessoa).Validar());
			_notificationContext.AddNotificationOrDefault(new IdPessoaValidator(_pessoaRepository, pessoa).Validar());


			if (_notificationContext.Valid)
				_pessoaRepository.Alterar(pessoa);
		}

		public void ExcluirPessoa(int id)
		{
			var pessoa = _pessoaRepository.Excluir(id);
			if (pessoa == null)
				_notificationContext.AddNotification("Id", "O Id informado não corresponde a nenhuma pessoa.");

		}

	}
}
