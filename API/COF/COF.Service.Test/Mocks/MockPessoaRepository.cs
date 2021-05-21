using COF.Domain.Entities;
using System;
using System.Collections.Generic;

namespace COF.Service.Test.Mocks
{
	public class MockPessoaRepository : BaseMock<Pessoa, MockPessoaRepository>
	{
		private readonly static IList<Pessoa> _pessoas = new List<Pessoa>()
			{
				new Pessoa(id: 1,
					   nome: "Henrique R. Firmino",
					   cpf: "055.820.631-05",
					   dataNascimento: new DateTime(year: 1995, month: 12, day: 8),
					   email: "henrique_rfirmino@hotmail.com",
					   telefone: "(65) 99661-8430",
					   usuario: "henrique3",
					   senha: "112353"),
				new Pessoa(id: 2,
					   nome: "Giulia Bueno",
					   cpf: "055.820.633-05",
					   dataNascimento: new DateTime(year: 1997, month: 7, day: 4),
					   email: "giuliabueno52@gmail.com",
					   telefone: "(65) 99661-8432",
					   usuario: "giulia",
					   senha: "435432")
		};

		public override IList<Pessoa> MassaDeDados => _pessoas;
	}
}
