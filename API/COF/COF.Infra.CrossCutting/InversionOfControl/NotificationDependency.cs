using COF.Infra.Shared.NotificationContext;
using Microsoft.Extensions.DependencyInjection;

namespace COF.Infra.CrossCutting.InversionOfControl
{
	public static class NotificationDependency
	{
		public static void AddNotificationDependency(this IServiceCollection services)
		{
			services.AddScoped<NotificationContext>();
		}
	}
}
