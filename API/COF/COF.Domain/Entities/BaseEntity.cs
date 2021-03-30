using Flunt.Notifications;
using System.ComponentModel.DataAnnotations.Schema;

namespace COF.Domain.Entities
{
	public abstract class BaseEntity<T> : Notifiable
	{
		protected BaseEntity(T id = default)
		{
			Id = id;
		}

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public virtual T Id { get; protected set; }
	}
}
