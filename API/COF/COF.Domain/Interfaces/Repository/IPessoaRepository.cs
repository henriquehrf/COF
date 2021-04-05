using COF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace COF.Domain.Interfaces.Repository
{
	public interface IPessoaRepository
	{
		Pessoa Inserir(Pessoa pessoa);
		Pessoa Alterar(Pessoa pessoa);
		Pessoa Excluir(int id);
		Pessoa ById(int id);
		Task<IList<Pessoa>> FilterAsync(Expression<Func<Pessoa, bool>> predicate);
	}
}
