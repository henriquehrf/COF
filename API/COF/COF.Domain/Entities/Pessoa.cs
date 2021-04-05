using COF.Domain.ValueTypes;
using System;
using System.Collections.Generic;

namespace COF.Domain.Entities
{
	public class Pessoa : BaseEntity<int>
	{
		public Pessoa(int id,
					  Nome nome, 
					  Cpf cpf, 
					  DateTime dataNascimento, 
					  Email email, 
					  Telefone telefone, 
					  Usuario usuario, 
					  Senha senha)
		{
			Id = id;
			Nome = nome;
			Cpf = cpf;
			DataNascimento = dataNascimento;
			Email = email;
			Telefone = telefone;
			Usuario = usuario;
			Senha = senha;

			AddNotifications(
				nome.Contract,
				cpf._contract,
				usuario.Contract,
				senha.Contract,
				telefone.Contract,
				email._contract);
		}

		public Nome Nome { get; }
		public Cpf Cpf { get; }
		public DateTime DataNascimento { get; }
		public Email Email { get; }
		public Telefone Telefone { get; }
		public Usuario Usuario { get; }
		public Senha Senha { get; }

		public virtual ICollection<ConfiguracaoObjetivo> ConfiguracaoObjetivos { get; } = new HashSet<ConfiguracaoObjetivo>();

	}
}
