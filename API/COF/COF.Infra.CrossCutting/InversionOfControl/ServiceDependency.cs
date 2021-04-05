using COF.Domain.Interfaces.Services;
using COF.Service.Service;
using Microsoft.Extensions.DependencyInjection;

namespace COF.Infra.CrossCutting.InversionOfControl
{
	public static class ServiceDependency
	{
		public static void AddServiceDependency(this IServiceCollection services)
		{
			services.AddScoped<IPessoaService, PessoaService>();
		}
	}
}
