using COF.Domain.Enum.Personalizacao;

namespace COF.Domain.Enum
{
	public enum TipoOperacao
	{

		[EnumAnnotation('E', "Entrada")]
		Entrada,
		[EnumAnnotation('S', "Saída")]
		Saida
	}
}
