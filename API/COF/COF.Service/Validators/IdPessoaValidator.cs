using COF.Domain.Entities;
using COF.Domain.Interfaces.Repository;
using Flunt.Notifications;

namespace COF.Service.Validators
{
	public class IdPessoaValidator : BaseValidator
	{

		public readonly IPessoaRepository _pessoaRepository;
		public readonly Pessoa _pessoa;

		public IdPessoaValidator(IPessoaRepository pessoaRepository, Pessoa pessoa)
		{
			_pessoaRepository = pessoaRepository;
			_pessoa = pessoa;
		}

		public override Notification Validar()
		{
			if ((_pessoa.Id) > 0 && (_pessoaRepository.ById(_pessoa.Id) == null))
				return new Notification("Id", $"O id {_pessoa.Id} não corresponde a uma pessoa cadastrada.");

			return null;
		}
	}
}
