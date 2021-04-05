using COF.Domain.Entities;
using COF.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace COF.Infra.Shared.ObjectMapper
{
	public static class PessoaMapper
	{
		public static Pessoa ToEntity(this PessoaModel objModel) => new Pessoa(id: objModel.Id,
																				nome: objModel.Nome,
																				cpf: objModel.Cpf,
																				dataNascimento: objModel.DataNascimento,
																				email: objModel.Email,
																				telefone: objModel.Telefone,
																				usuario: objModel.Usuario,
																				senha: objModel.Senha);

		public static PessoaModel ToModel(this Pessoa objRepository) => new PessoaModel()
		{
			Id = objRepository.Id,
			Nome = objRepository.Nome.ToString(),
			Cpf = objRepository.Cpf.ToString(),
			DataNascimento = objRepository.DataNascimento,
			Email = objRepository.Email.ToString(),
			Telefone = objRepository.Telefone.ToString(),
			Usuario = objRepository.Usuario.ToString()
		};

		public static IEnumerable<PessoaModel> ToEnumerableModel(this IList<Pessoa> list) => new List<PessoaModel>(list.Select(obj => ToModel(obj)));
	}
}
