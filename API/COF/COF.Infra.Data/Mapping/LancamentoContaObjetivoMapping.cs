using COF.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace COF.Infra.Data.Mapping
{
	public class LancamentoContaObjetivoMapping : IEntityTypeConfiguration<LancamentoContaObjetivo>
	{
		public void Configure(EntityTypeBuilder<LancamentoContaObjetivo> builder)
		{
			builder.ToTable(nameof(LancamentoContaObjetivo));

			builder.HasKey(prop => prop.Id);

			builder.Property(prop => prop.IdContaObjetivo)
			   .IsRequired()
			   .HasColumnName("IdContaObjetivo")
			   .HasColumnType("int");

			builder.Property(prop => prop.ValorLancamento)
			   .HasConversion(prop => prop.Valor(), prop => prop)
			   .IsRequired()
			   .HasColumnName("ValorLancamento")
			   .HasColumnType("decimal(18,2)");

			builder.Property(prop => prop.DataHoraOperacao)
			   .IsRequired()
			   .HasColumnName("DataHoraOperacao")
			   .HasColumnType("datetime");

			builder.Property(prop => prop.TipoOperacao)
			   .IsRequired()
			   .HasColumnName("TipoOperacao")
			   .HasColumnType("char(1)");

			builder.Property(prop => prop.Observacao)
			   .HasColumnName("Observacao")
			   .HasColumnType("varchar(500)");

			builder.HasOne(prop => prop.ContaObjetivo)
			  .WithMany(prop => prop.LancamentosContaObjetivo)
			  .HasPrincipalKey(prop => prop.Id)
			  .HasForeignKey(prop => prop.IdContaObjetivo);
		}
	}
}
