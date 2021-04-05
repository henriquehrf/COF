using COF.Domain.Entities;
using COF.Domain.Interfaces.Repository;
using COF.Infra.Data.Context;

namespace COF.Infra.Data.Repository
{
	public class PessoaRepository : BaseRepository<Pessoa, int>, IPessoaRepository
	{
		public PessoaRepository(COFContext context) : base(context)
		{
		}
	}
}
