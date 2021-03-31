using System;

namespace COF.Domain.Enum.Personalizacao
{
	public sealed class EnumAnnotation : Attribute
	{
		public EnumAnnotation(object valor, string descricao)
		{
			Valor = valor;
			Descricao = descricao;
		}

		public object Valor { get; }
		public string Descricao { get; }

		public override string ToString()
		{
			return Descricao;
		}

		public T RetornarValor<T>()
		{
			if (Valor is T)
				return (T)Valor;

			return default;
		}
	}
}
