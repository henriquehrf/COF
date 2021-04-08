using COF.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace COF.Domain.Interfaces.Repository
{
	public interface IPessoaRepository
	{
		Pessoa Inserir(Pessoa pessoa);
		Pessoa Alterar(Pessoa pessoa);
		Pessoa Excluir(int id);
		Pessoa ById(int id);
		IQueryable<Pessoa> Filter(Expression<Func<Pessoa, bool>> predicate);
		IQueryable<Pessoa> Todos();

	}
}
