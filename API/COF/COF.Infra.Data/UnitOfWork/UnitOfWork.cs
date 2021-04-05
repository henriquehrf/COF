using COF.Domain.Interfaces.UnitOfWork;
using COF.Infra.Data.Context;
using System.Threading.Tasks;

namespace COF.Infra.Data.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		protected readonly COFContext _cofContext;

		public UnitOfWork(COFContext cofContext)
		{
			_cofContext = cofContext;
		}

		public void Commit()
		{
			_cofContext.SaveChanges();
		}
	}
}
