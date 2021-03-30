using COF.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace COF.Infra.Data.Mapping
{
	public class ContaObjetivoMapping : IEntityTypeConfiguration<ContaObjetivo>
	{

		public void Configure(EntityTypeBuilder<ContaObjetivo> builder)
		{
			builder.ToTable(nameof(ContaObjetivo));

			builder.HasKey(prop => prop.Id);

			builder.Property(prop => prop.IdConfiguracaoObjetivo)
			   .IsRequired()
			   .HasColumnName("IdConfiguracaoObjetivo")
			   .HasColumnType("int");


			builder.Property(prop => prop.Descricao)
			   .IsRequired()
			   .HasColumnName("Descricao")
			   .HasColumnType("varchar(50)");


			builder.Property(prop => prop.SaldoConta)
			   .IsRequired()
				.HasConversion(prop => prop.Valor(), prop => prop)
			   .HasColumnName("SaldoConta")
			   .HasColumnType("decimal(18,2)");

			builder.Property(prop => prop.LimiteObjetivo)
				.HasConversion(prop => prop.Valor(), prop => prop)
			   .HasColumnName("LimiteObjetivo")
			   .HasColumnType("decimal(18,2)");

			builder.Property(prop => prop.Ativo)
			   .IsRequired()
			   .HasDefaultValueSql("1")
			   .HasColumnName("Ativo")
			   .HasColumnType("bit");

			builder.Property(prop => prop.GrauImportancia)
			   .IsRequired()
				.HasDefaultValueSql("0")
			   .HasColumnName("GrauImportancia")
			   .HasColumnType("smallInt");

			builder.Property(prop => prop.EhContaTemporaria)
			   .IsRequired()
				.HasDefaultValueSql("0")
			   .HasColumnName("EhContaTemporaria")
			   .HasColumnType("bit");

			builder.Property(prop => prop.DataHoraAlcance)
			   .HasDefaultValueSql("NULL")
			   .HasColumnName("DataHoraAlcance")
			   .HasColumnType("datetime");

			builder.HasOne(prop => prop.Objetivo)
			  .WithMany(prop => prop.ConfiguracaoObjetivos)
			  .HasPrincipalKey(prop => prop.Id)
			  .HasForeignKey(prop => prop.IdConfiguracaoObjetivo);
		}
	}
}
