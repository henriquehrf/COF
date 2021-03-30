﻿// <auto-generated />
using System;
using COF.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace COF.Infra.Data.Migrations
{
    [DbContext(typeof(COFContext))]
    [Migration("20210330220244_AdicionadoContaObjetivo")]
    partial class AdicionadoContaObjetivo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("COF.Domain.Entities.ConfiguracaoObjetivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EhProprietario")
                        .HasColumnType("bit")
                        .HasColumnName("EhProprietario");

                    b.Property<int>("IdPermissaoPessoa")
                        .HasColumnType("int")
                        .HasColumnName("IdPermissaoPessoa");

                    b.Property<int>("IdPessoa")
                        .HasColumnType("int")
                        .HasColumnName("IdPessoa");

                    b.HasKey("Id");

                    b.HasIndex("IdPermissaoPessoa");

                    b.HasIndex("IdPessoa");

                    b.ToTable("ConfiguracaoObjetivo");
                });

            modelBuilder.Entity("COF.Domain.Entities.ContaObjetivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("Ativo")
                        .HasDefaultValueSql("1");

                    b.Property<DateTime?>("DataHoraAlcance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("DataHoraAlcance")
                        .HasDefaultValueSql("NULL");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Descricao");

                    b.Property<bool>("EhContaTemporaria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasColumnName("EhContaTemporaria")
                        .HasDefaultValueSql("0");

                    b.Property<short>("GrauImportancia")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallInt")
                        .HasColumnName("GrauImportancia")
                        .HasDefaultValueSql("0");

                    b.Property<int>("IdConfiguracaoObjetivo")
                        .HasColumnType("int")
                        .HasColumnName("IdConfiguracaoObjetivo");

                    b.Property<decimal?>("LimiteObjetivo")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("LimiteObjetivo");

                    b.Property<decimal>("SaldoConta")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("SaldoConta");

                    b.HasKey("Id");

                    b.HasIndex("IdConfiguracaoObjetivo");

                    b.ToTable("ContaObjetivo");
                });

            modelBuilder.Entity("COF.Domain.Entities.PermissaoPessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Descricao");

                    b.HasKey("Id");

                    b.ToTable("PermissaoPessoa");
                });

            modelBuilder.Entity("COF.Domain.Entities.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("varchar(14)")
                        .HasColumnName("Cpf");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("Datetime")
                        .HasColumnName("DataNascimento");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasColumnName("Senha");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Telefone");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Usuario");

                    b.HasKey("Id");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("COF.Domain.Entities.ConfiguracaoObjetivo", b =>
                {
                    b.HasOne("COF.Domain.Entities.PermissaoPessoa", "PermissaoPessoa")
                        .WithMany("ConfiguracaoObjetivos")
                        .HasForeignKey("IdPermissaoPessoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("COF.Domain.Entities.Pessoa", "Pessoa")
                        .WithMany("ConfiguracaoObjetivos")
                        .HasForeignKey("IdPessoa")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PermissaoPessoa");

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("COF.Domain.Entities.ContaObjetivo", b =>
                {
                    b.HasOne("COF.Domain.Entities.ConfiguracaoObjetivo", "Objetivo")
                        .WithMany("ConfiguracaoObjetivos")
                        .HasForeignKey("IdConfiguracaoObjetivo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Objetivo");
                });

            modelBuilder.Entity("COF.Domain.Entities.ConfiguracaoObjetivo", b =>
                {
                    b.Navigation("ConfiguracaoObjetivos");
                });

            modelBuilder.Entity("COF.Domain.Entities.PermissaoPessoa", b =>
                {
                    b.Navigation("ConfiguracaoObjetivos");
                });

            modelBuilder.Entity("COF.Domain.Entities.Pessoa", b =>
                {
                    b.Navigation("ConfiguracaoObjetivos");
                });
#pragma warning restore 612, 618
        }
    }
}
