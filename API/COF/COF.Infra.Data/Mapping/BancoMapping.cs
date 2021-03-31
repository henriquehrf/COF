using COF.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace COF.Infra.Data.Mapping
{
	public class BancoMapping : IEntityTypeConfiguration<Banco>
	{
		public void Configure(EntityTypeBuilder<Banco> builder)
		{
			builder.ToTable(nameof(Banco));

			builder.HasKey(prop => prop.Id);

			builder.Property(prop => prop.Nome)
			   .HasConversion(prop => prop.ToString(), prop => prop)
			   .IsRequired()
			   .HasColumnName("Nome")
			   .HasColumnType("varchar(50)");

			builder.Property(prop => prop.Codigo)
			   .IsRequired()
			   .HasColumnName("Codigo")
			   .HasColumnType("int");

			builder.Property(prop => prop.GuidLogo)
			   .IsRequired()
			   .HasColumnName("GuidLogo")
			   .HasColumnType("uniqueidentifier");
		}
	}
}
