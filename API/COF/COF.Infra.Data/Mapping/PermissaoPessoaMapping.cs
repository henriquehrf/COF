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
	public class PermissaoPessoaMapping : IEntityTypeConfiguration<PermissaoPessoa>
	{
		public void Configure(EntityTypeBuilder<PermissaoPessoa> builder)
		{
			builder.ToTable("PermissaoPessoa");

			builder.HasKey(prop => prop.Id);

			builder.Property(prop => prop.Descricao)
			   .IsRequired()
			   .HasColumnName("Descricao")
			   .HasColumnType("varchar(20)");
		}
	}
}
