using COF.Domain.Entities;
using COF.Domain.Interfaces.Repository;
using COF.Infra.Shared.NotificationContext;
using COF.Service.Service;
using COF.Service.Test.Mocks;
using FluentAssertions;
using Flunt.Notifications;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Xunit;

namespace COF.Service.Test.PessoaServiceTest
{
	public class IncluirPessoaTest
	{
		private readonly Mock<IPessoaRepository> _pessoaRepository;
		private readonly Mock<NotificationContext> _notificationContext;
		private readonly PessoaService _pessoaService;

		public IncluirPessoaTest()
		{
			_pessoaRepository = new Mock<IPessoaRepository>();
			_notificationContext = new Mock<NotificationContext>();
			_pessoaService = new PessoaService(_pessoaRepository.Object, _notificationContext.Object);
		}

		[Theory]
		[MemberData(nameof(ParametrosEsperados))]
		public void AoIncluirUmaPessoaDeveValidarERetornarMensagemValidacaoCasoHouver(Pessoa pessoaInclusao, bool ehValido, Notification notifications)
		{
			SetupTest();

			_pessoaService.InserirPessoa(pessoaInclusao);

			_notificationContext.Object.Valid.Should().Be(ehValido);
			if (!ehValido)
				_notificationContext.Object.Notifications.Should().ContainEquivalentOf(notifications);

		}

		private void SetupTest()
		{
			_pessoaRepository.Setup(s => s.Filter(It.IsAny<Expression<Func<Pessoa, bool>>>()))
							 .Returns<Expression<Func<Pessoa, bool>>>(predicate => MockPessoaRepository.Filter(predicate));

			_pessoaRepository.Setup(s => s.ById(It.IsAny<int>()))
							 .Returns((int id) => MockPessoaRepository.ById(id));
		}


		public static IEnumerable<object[]> ParametrosEsperados()
		{
			yield return new object[]
			{

				new Pessoa(id:0,
						  nome:"Henrique R. Firmino",
						  cpf:"055.820.631-05",
						  dataNascimento: new DateTime(year: 1995, month: 12, day:8),
						  email:"henrique_rfirmino@hotmail.com",
						  telefone: "(65) 99661-8430",
						  usuario: "henrique",
						  senha: "112345"),
				false,
				new Notification("CPF", "O CPF 055.820.631-05 já está cadastrado a uma pessoa."),
			};

			yield return new object[]
			{
				new Pessoa(id:0,
						   nome:"Henrique R. Firmino",
						   cpf:"055.820.631-15",
						   dataNascimento: new DateTime(year: 1995, month: 12, day:8),
						   email:"henrique_rfirmino@hotmail.com",
						   telefone: "(65) 99661-8430",
						   usuario: "henrique3",
						   senha: "112345"),
				false,
				new Notification("Usuario", "O usuário henrique3 já está cadastrado a uma pessoa."),
			};

			yield return new object[]
			{
				new Pessoa(id:0,
						   nome:"Henrique R. Firmino",
						   cpf:"055.820.631-15",
						   dataNascimento: new DateTime(year: 1995, month: 12, day:8),
						   email:"henrique_rfirmino@hotmail.com",
						   telefone: "(65) 99661-8430",
						   usuario: "henrique64",
						   senha: "112345"),
				true,
				null,
			};
		}
	}
}
