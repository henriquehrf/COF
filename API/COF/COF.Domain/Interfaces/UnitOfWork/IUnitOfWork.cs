using System.Threading.Tasks;

namespace COF.Domain.Interfaces.UnitOfWork
{
	public interface IUnitOfWork
	{
		public void Commit();
	}
}
