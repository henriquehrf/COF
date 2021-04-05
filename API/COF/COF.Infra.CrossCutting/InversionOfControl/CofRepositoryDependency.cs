using COF.Domain.Interfaces.Repository;
using COF.Domain.Interfaces.UnitOfWork;
using COF.Infra.Data.Repository;
using COF.Infra.Data.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace COF.Infra.CrossCutting.InversionOfControl
{
	public static class CofRepositoryDependency
	{
		public static void AddSqlRepositoryDependency(this IServiceCollection services)
		{
			services.AddScoped<IUnitOfWork, UnitOfWork>();
			services.AddScoped<IPessoaRepository, PessoaRepository>();
		}
	}
}
