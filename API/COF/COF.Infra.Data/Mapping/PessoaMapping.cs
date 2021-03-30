using COF.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace COF.Infra.Data.Mapping
{
	public class PessoaMapping : IEntityTypeConfiguration<Pessoa>
	{

		public void Configure(EntityTypeBuilder<Pessoa> builder)
		{
			builder.ToTable("Usuario");

			builder.HasKey(prop => prop.Id);

			builder.Property(prop => prop.Nome)
			   .HasConversion(prop => prop.ToString(), prop => prop)
			   .IsRequired()
			   .HasColumnName("Nome")
			   .HasColumnType("varchar(100)");

			builder.Property(prop => prop.Cpf)
			  .HasConversion(prop => prop.ToString(), prop => prop)
			  .IsRequired()
			  .HasColumnName("Cpf")
			  .HasColumnType("varchar(14)");

			builder.Property(prop => prop.DataNascimento)
			  .HasColumnName("DataNascimento")
			  .HasColumnType("Datetime");

			builder.Property(prop => prop.Telefone)
			  .HasConversion(prop => prop.ToString(), prop => prop)
			  .HasColumnName("Telefone")
			  .HasColumnType("varchar(20)");

			builder.Property(prop => prop.Email)
			  .HasConversion(prop => prop.ToString(), prop => prop)
			  .HasColumnName("Email")
			   .IsRequired()
			  .HasColumnType("varchar(100)");

			builder.Property(prop => prop.Usuario)
			  .IsRequired()
			  .HasColumnName("Usuario")
			  .HasColumnType("varchar(20)");

			builder.Property(prop => prop.Senha)
			 .IsRequired()
			  .HasColumnName("Senha")
			  .HasColumnType("varchar(500)");
		}
	}
}
