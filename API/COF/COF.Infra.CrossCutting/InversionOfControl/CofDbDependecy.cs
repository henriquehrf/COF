using COF.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace COF.Infra.CrossCutting.InversionOfControl
{
	public static class CofDbDependecy
	{
		public static void AddDependencySql(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<COFContext>(context =>
			{
				context.UseSqlServer(configuration["ConnectionString"]);
			});
		}
	}
}
