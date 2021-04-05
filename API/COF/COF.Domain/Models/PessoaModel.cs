using System;

namespace COF.Domain.Models
{
	public sealed class PessoaModel
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Cpf { get; set; }
		public DateTime DataNascimento { get; set; }
		public string Email { get; set; }
		public string Telefone { get; set; }
		public string Usuario { get; set; }
		public string Senha { get; set; }
	}
}
