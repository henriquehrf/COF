using Flunt.Notifications;

namespace COF.Infra.Shared.NotificationContext
{
	public class NotificationContext : Notifiable
	{

		public void AddNotificationOrDefault(Notification notification)
		{
			if (notification == null)
				return;

			AddNotification(notification);
		}
	}
}
