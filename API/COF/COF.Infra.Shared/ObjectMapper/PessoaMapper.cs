using COF.Domain.Entities;
using COF.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace COF.Infra.Shared.ObjectMapper
{
	public static class PessoaMapper
	{
		public static Pessoa ToEntity(this PessoaViewModel objModel) => new Pessoa(id: objModel.Id,
																				nome: objModel.Nome,
																				cpf: objModel.Cpf,
																				dataNascimento: objModel.DataNascimento,
																				email: objModel.Email,
																				telefone: objModel.Telefone,
																				usuario: objModel.Usuario,
																				senha: objModel.Senha);

		public static PessoaViewModel ToModel(this Pessoa objRepository) => new PessoaViewModel()
		{
			Id = objRepository.Id,
			Nome = objRepository.Nome.ToString(),
			Cpf = objRepository.Cpf.ToString(),
			DataNascimento = objRepository.DataNascimento,
			Email = objRepository.Email.ToString(),
			Telefone = objRepository.Telefone.ToString(),
			Usuario = objRepository.Usuario.ToString()
		};

		public static IList<PessoaViewModel> ToEnumerableModel(this IList<Pessoa> list) => new List<PessoaViewModel>(list.Select(obj => ToModel(obj)));
	}
}
