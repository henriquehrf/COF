using COF.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace COF.Infra.Data.Mapping
{
	public class ContaBancariaMapping : IEntityTypeConfiguration<ContaBancaria>
	{
		public void Configure(EntityTypeBuilder<ContaBancaria> builder)
		{
			builder.ToTable(nameof(ContaBancaria));

			builder.HasKey(prop => prop.Id);

			builder.Property(prop => prop.Nome)
			   .HasConversion(prop => prop.ToString(), prop => prop)
			   .IsRequired()
			   .HasColumnName("Nome")
			   .HasColumnType("varchar(50)");

			builder.Property(prop => prop.SaldoConta)
				.HasConversion(prop => prop.Valor(), prop => prop)
			   .IsRequired()
			   .HasColumnName("SaldoConta")
			   .HasColumnType("decimal(18,2)");

			builder.Property(prop => prop.IdBanco)
			   .IsRequired()
			   .HasColumnName("IdBanco")
			   .HasColumnType("int");

			builder.Property(prop => prop.IdConfiguracaoObjetivo)
			   .IsRequired()
			   .HasColumnName("IdConfiguracaoObjetivo")
			   .HasColumnType("int");

			builder.HasOne(prop => prop.Banco)
			  .WithMany(prop => prop.ContasBancarias)
			  .HasPrincipalKey(prop => prop.Id)
			  .HasForeignKey(prop => prop.IdBanco);

			builder.HasOne(prop => prop.ConfiguracaoObjetivo)
		    .WithMany(prop => prop.ContasBancarias)
		    .HasPrincipalKey(prop => prop.Id)
		    .HasForeignKey(prop => prop.IdConfiguracaoObjetivo);
		}
	}
}
