using COF.Domain.Entities;
using COF.Infra.Data.Mapping;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;

namespace COF.Infra.Data.Context
{
	public class COFContext : DbContext
	{
		public COFContext(DbContextOptions<COFContext> options) : base(options)
		{
		}

		public DbSet<Pessoa> Pessoa { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Pessoa>(new PessoaMapping().Configure);
			modelBuilder.Entity<PermissaoPessoa>(new PermissaoPessoaMapping().Configure);
			modelBuilder.Entity<ConfiguracaoObjetivo>(new ConfiguracaoObjetivoMapping().Configure);
			modelBuilder.Entity<ContaObjetivo>(new ContaObjetivoMapping().Configure);
			modelBuilder.Entity<Banco>(new BancoMapping().Configure);
			modelBuilder.Entity<ContaBancaria>(new ContaBancariaMapping().Configure);
			modelBuilder.Entity<LancamentoContaObjetivo>(new LancamentoContaObjetivoMapping().Configure);
			modelBuilder.Entity<LancamentoContaBancaria>(new LancamentoContaBancariaMapping().Configure);

			var entites = Assembly
				.Load("COF.Domain")
				.GetTypes()
				.Where(w => w.Namespace == "COF.Domain.Entities" && w.BaseType.BaseType == typeof(Notifiable));

			foreach (var item in entites)
			{
				modelBuilder.Entity(item).Ignore(nameof(Notifiable.Invalid));
				modelBuilder.Entity(item).Ignore(nameof(Notifiable.Valid));
				modelBuilder.Entity(item).Ignore(nameof(Notifiable.Notifications));
			}
		}
	}
}
