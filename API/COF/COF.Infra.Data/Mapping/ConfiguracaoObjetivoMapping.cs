using COF.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COF.Infra.Data.Mapping
{
	public class ConfiguracaoObjetivoMapping : IEntityTypeConfiguration<ConfiguracaoObjetivo>
	{
		public void Configure(EntityTypeBuilder<ConfiguracaoObjetivo> builder)
		{
			builder.ToTable("ConfiguracaoObjetivo");

			builder.HasKey(prop => prop.Id);

			builder.Property(prop => prop.IdPessoa)
			   .IsRequired()
			   .HasColumnName("IdPessoa")
			   .HasColumnType("int");

			builder.Property(prop => prop.IdPermissaoPessoa)
			   .IsRequired()
			   .HasColumnName("IdPermissaoPessoa")
			   .HasColumnType("int");


			builder.Property(prop => prop.EhProprietario)
			   .IsRequired()
			   .HasColumnName("EhProprietario")
			   .HasColumnType("bit");

			builder.HasOne(prop => prop.Pessoa)
				.WithMany(prop => prop.ConfiguracaoObjetivos)
				.HasPrincipalKey(prop => prop.Id)
				.HasForeignKey(prop => prop.IdPessoa);

			builder.HasOne(prop => prop.PermissaoPessoa)
			  .WithMany(prop => prop.ConfiguracaoObjetivos)
			  .HasPrincipalKey(prop => prop.Id)
			  .HasForeignKey(prop => prop.IdPermissaoPessoa);
		}
	}
}
