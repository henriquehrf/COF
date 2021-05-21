using COF.Domain.Entities;
using COF.Domain.Interfaces.Repository;
using Flunt.Notifications;
using System.Linq;

namespace COF.Service.Validators
{
	public class CpfValidator : BaseValidator
	{
		public readonly IPessoaRepository _pessoaRepository;
		public readonly Pessoa _pessoa;

		public CpfValidator(IPessoaRepository pessoaRepository, Pessoa pessoa)
		{
			_pessoaRepository = pessoaRepository;
			_pessoa = pessoa;
		}

		public override Notification Validar()
		{
			if ((_pessoaRepository.Filter(p => (p.Cpf.ToString().Equals(_pessoa.Cpf.ToString()) && p.Id != _pessoa.Id))).Any())
				return new Notification("CPF", $"O CPF {_pessoa.Cpf} já está cadastrado a uma pessoa.");

			return null;
		}
	}
}
