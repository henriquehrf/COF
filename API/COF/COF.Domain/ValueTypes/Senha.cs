using Flunt.Validations;

namespace COF.Domain.ValueTypes
{
	public struct Senha
	{
		public Contract Contract { get; }

		private readonly string _valor;

		public Senha(string value)
		{
			_valor = value;
			Contract = new Contract();
			Validar();
		}

		public override string ToString() => _valor;

		public static implicit operator Senha(string value) => new Senha(value);

		private bool Validar()
		{
			if (string.IsNullOrWhiteSpace(_valor))
				return AdicionarNotificacao("Obrigatório informar uma senha.");

			if (_valor.Length < 6)
				return AdicionarNotificacao("A senha não pode ter menos que 6 caracteres.");

			return true;
		}

		private bool AdicionarNotificacao(string mensagem)
		{
			Contract.AddNotification(nameof(Senha), mensagem);
			return false;
		}
	}
}
