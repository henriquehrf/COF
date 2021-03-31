using COF.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace COF.Infra.Data.Mapping
{
	public class LancamentoContaBancariaMapping : IEntityTypeConfiguration<LancamentoContaBancaria>
	{

		public void Configure(EntityTypeBuilder<LancamentoContaBancaria> builder)
		{
			builder.ToTable(nameof(LancamentoContaBancaria));

			builder.HasKey(prop => prop.Id);

			builder.Property(prop => prop.IdContaCorrente)
			   .IsRequired()
			   .HasColumnName("IdContaCorrente")
			   .HasColumnType("int");

			builder.Property(prop => prop.Descricao)
			   .IsRequired()
			   .HasColumnName("Descricao")
			   .HasColumnType("varchar(50)");

			builder.Property(prop => prop.DataHoraLancamento)
			   .IsRequired()
			   .HasColumnName("DataHoraLancamento")
			   .HasColumnType("datetime");

			builder.Property(prop => prop.ValorLancamento)
			   .HasConversion(prop => prop.Valor(), prop => prop)
			   .IsRequired()
			   .HasColumnName("ValorLancamento")
			   .HasColumnType("decimal(18,2)");

			builder.Property(prop => prop.TipoOperacao)
			   .IsRequired()
			   .HasColumnName("TipoOperacao")
			   .HasColumnType("char(1)");

			builder.Property(prop => prop.GuidComprovante)
			   .HasColumnName("GuidComprovante")
			   .HasColumnType("uniqueidentifier");

			builder.HasOne(prop => prop.ContaBancaria)
			  .WithMany(prop => prop.LancamentosContaObjetivo)
			  .HasPrincipalKey(prop => prop.Id)
			  .HasForeignKey(prop => prop.IdContaCorrente);
		}
	}
}
