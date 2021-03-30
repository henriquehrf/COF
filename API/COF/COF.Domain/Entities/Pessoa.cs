﻿using COF.Domain.ValueTypes;
using System;

namespace COF.Domain.Entities
{
	public class Pessoa : BaseEntity<int>
	{
		public Pessoa(Nome nome, 
					  Cpf cpf, 
					  DateTime dataNascimento, 
					  Email email, 
					  Telefone telefone, 
					  Usuario usuario, 
					  Senha senha)
		{
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
	}
}
