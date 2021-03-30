using Flunt.Validations;

namespace COF.Domain.ValueTypes
{
	public class Saldo
	{
		public Contract Contract { get; }

		private readonly decimal? _valor;

		private Saldo(decimal? value)
		{
			_valor = value;
			Contract = new Contract();
			Validar();
		}

		public override string ToString() => string.Format("{0:C}", _valor);

		public decimal? Valor () => _valor;

		public static implicit operator Saldo(decimal? value) => new Saldo(value);

		private bool Validar()
		{
			if (_valor.HasValue && _valor.Value < 0)
				return AdicionarNotificacao("O valor do saldo não pode ser negativo.");

			return true;
		}

		private bool AdicionarNotificacao(string mensagem)
		{
			Contract.AddNotification(nameof(Saldo), mensagem);
			return false;
		}
	}
}
