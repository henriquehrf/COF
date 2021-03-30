using Flunt.Notifications;

namespace COF.Domain.Entities
{
	public abstract class BaseEntity<T> : Notifiable
	{
		protected BaseEntity(T id = default)
		{
			Id = id;
		}

		public virtual T Id { get; protected set; }
	}
}
