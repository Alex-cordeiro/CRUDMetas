﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Telemetrix.API.Context;

namespace Telemetrix.API.Migrations
{
    [DbContext(typeof(MetasContext))]
    [Migration("20220629192740_alteracao_campos_nullable_tabelas")]
    partial class alteracao_campos_nullable_tabelas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Telemetrix.API.Model.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("Telemetrix.API.Model.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeEmpresa")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("Telemetrix.API.Model.Peca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataValidade")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DepartamentoId")
                        .HasColumnType("int");

                    b.Property<int?>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<int?>("SetorId")
                        .HasColumnType("int");

                    b.Property<int?>("Tipo")
                        .HasColumnType("int");

                    b.Property<float>("Valor")
                        .HasColumnType("real");

                    b.Property<int?>("VendedorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("SetorId");

                    b.HasIndex("VendedorId");

                    b.ToTable("Pecas");
                });

            modelBuilder.Entity("Telemetrix.API.Model.Servico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataValidade")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DepartamentoId")
                        .HasColumnType("int");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<int?>("SetorId")
                        .HasColumnType("int");

                    b.Property<int?>("Tipo")
                        .HasColumnType("int");

                    b.Property<float>("Valor")
                        .HasColumnType("real");

                    b.Property<int?>("VendedorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("SetorId");

                    b.HasIndex("VendedorId");

                    b.ToTable("Servicos");
                });

            modelBuilder.Entity("Telemetrix.API.Model.Setor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Setores");
                });

            modelBuilder.Entity("Telemetrix.API.Model.TipoEntradaMeta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TiposEntradasMetas");
                });

            modelBuilder.Entity("Telemetrix.API.Model.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SobreNome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Telemetrix.API.Model.Veiculo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataValidade")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartamentoId")
                        .HasColumnType("int");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("Familia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Quantidade")
                        .HasColumnType("int");

                    b.Property<int?>("SetorId")
                        .HasColumnType("int");

                    b.Property<int?>("Tipo")
                        .HasColumnType("int");

                    b.Property<float>("Valor")
                        .HasColumnType("real");

                    b.Property<int?>("VendedorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("Telemetrix.API.Model.Vendedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Vendedores");
                });

            modelBuilder.Entity("Telemetrix.API.Model.Departamento", b =>
                {
                    b.HasOne("Telemetrix.API.Model.Empresa", null)
                        .WithMany("EmpresaDepartamentos")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Telemetrix.API.Model.Peca", b =>
                {
                    b.HasOne("Telemetrix.API.Model.Departamento", "Departamento")
                        .WithMany()
                        .HasForeignKey("DepartamentoId");

                    b.HasOne("Telemetrix.API.Model.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId");

                    b.HasOne("Telemetrix.API.Model.Setor", "Setor")
                        .WithMany()
                        .HasForeignKey("SetorId");

                    b.HasOne("Telemetrix.API.Model.Vendedor", "Vendedor")
                        .WithMany()
                        .HasForeignKey("VendedorId");

                    b.Navigation("Departamento");

                    b.Navigation("Empresa");

                    b.Navigation("Setor");

                    b.Navigation("Vendedor");
                });

            modelBuilder.Entity("Telemetrix.API.Model.Servico", b =>
                {
                    b.HasOne("Telemetrix.API.Model.Departamento", "Departamento")
                        .WithMany()
                        .HasForeignKey("DepartamentoId");

                    b.HasOne("Telemetrix.API.Model.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Telemetrix.API.Model.Setor", "Setor")
                        .WithMany()
                        .HasForeignKey("SetorId");

                    b.HasOne("Telemetrix.API.Model.Vendedor", "Vendedor")
                        .WithMany()
                        .HasForeignKey("VendedorId");

                    b.Navigation("Departamento");

                    b.Navigation("Empresa");

                    b.Navigation("Setor");

                    b.Navigation("Vendedor");
                });

            modelBuilder.Entity("Telemetrix.API.Model.Veiculo", b =>
                {
                    b.HasOne("Telemetrix.API.Model.Departamento", "Departamento")
                        .WithMany()
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");
                });

            modelBuilder.Entity("Telemetrix.API.Model.Vendedor", b =>
                {
                    b.HasOne("Telemetrix.API.Model.Empresa", null)
                        .WithMany("Vendedores")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Telemetrix.API.Model.Empresa", b =>
                {
                    b.Navigation("EmpresaDepartamentos");

                    b.Navigation("Vendedores");
                });
#pragma warning restore 612, 618
        }
    }
}
