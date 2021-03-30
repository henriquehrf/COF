using Flunt.Validations;

namespace COF.Domain.ValueTypes
{
	public struct Usuario
	{
		public Contract Contract { get; }

		private readonly string _valor;

		public Usuario(string value)
		{
			_valor = value;
			Contract = new Contract();
			Validar();
		}

		public override string ToString() => _valor;

		public static implicit operator Usuario(string value) => new Usuario(value);

		private bool Validar()
		{
			if (string.IsNullOrWhiteSpace(_valor))
				return AdicionarNotificacao("Obrigatório informar um usuário.");

			if (_valor.Length < 3)
				return AdicionarNotificacao("Um usuário não pode ter menos que 3 caracteres.");

			if (_valor.Length > 20)
				return AdicionarNotificacao("Um usuário não pode ter mais que 20 caracteres.");

			if (char.IsDigit(_valor.Substring(0, 1), 0))
				return AdicionarNotificacao("Um usuário não pode iniciar com um número.");

			return true;
		}

		private bool AdicionarNotificacao(string mensagem)
		{
			Contract.AddNotification(nameof(Usuario), mensagem);
			return false;
		}
	}
}
