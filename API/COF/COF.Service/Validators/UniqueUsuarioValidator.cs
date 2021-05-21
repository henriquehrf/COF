using COF.Domain.Entities;
using COF.Domain.Interfaces.Repository;
using Flunt.Notifications;
using System.Linq;

namespace COF.Service.Validators
{
	public class UniqueUsuarioValidator : BaseValidator
	{
		private readonly IPessoaRepository _pessoaRepository;
		private readonly Pessoa _pessoa;

		public UniqueUsuarioValidator(IPessoaRepository pessoaRepository, Pessoa pessoa)
		{
			_pessoaRepository = pessoaRepository;
			_pessoa = pessoa;
		}

		public override Notification Validar()
		{
			if ((_pessoaRepository.Filter(p => (p.Usuario.ToString().Equals(_pessoa.Usuario.ToString()) && p.Id != _pessoa.Id))).Any())
				return new Notification("Usuario", $"O usuário {_pessoa.Usuario} já está cadastrado a uma pessoa.");

			return null;
		}
	}
}
