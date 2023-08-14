﻿// <auto-generated />
using APIRelacionamento.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APIRelacionamento.Migrations
{
    [DbContext(typeof(SistemaConsultasDBContext))]
    [Migration("20230814182311_v1")]
    partial class v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("APIRelacionamento.Models.ColaboradorModel", b =>
                {
                    b.Property<int>("idColaborador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idColaborador"), 1L, 1);

                    b.Property<string>("CepColaborador")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("salario")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("idColaborador");

                    b.HasIndex("CepColaborador");

                    b.ToTable("Colaboradores");
                });

            modelBuilder.Entity("APIRelacionamento.Models.DependenteModel", b =>
                {
                    b.Property<int>("idDependente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idDependente"), 1L, 1);

                    b.Property<int>("ColaboradorId")
                        .HasColumnType("int");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("sobrenome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("idDependente");

                    b.HasIndex("ColaboradorId");

                    b.ToTable("Dependentes");
                });

            modelBuilder.Entity("APIRelacionamento.Models.ViaCepModel", b =>
                {
                    b.Property<string>("Cep")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Bairro")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Bairro");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Complemento");

                    b.Property<string>("DDD")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DDD");

                    b.Property<string>("Gia")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Gia");

                    b.Property<string>("Ibge")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Ibge");

                    b.Property<string>("Localidade")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Localidade");

                    b.Property<string>("Logradouro")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Logradouro");

                    b.Property<string>("Siafi")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Siafi");

                    b.Property<string>("Uf")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Uf");

                    b.HasKey("Cep");

                    b.ToTable("InfoCep");
                });

            modelBuilder.Entity("APIRelacionamento.Models.ColaboradorModel", b =>
                {
                    b.HasOne("APIRelacionamento.Models.ViaCepModel", "ViaCep")
                        .WithMany("Colaboradores")
                        .HasForeignKey("CepColaborador")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ViaCep");
                });

            modelBuilder.Entity("APIRelacionamento.Models.DependenteModel", b =>
                {
                    b.HasOne("APIRelacionamento.Models.ColaboradorModel", "Colaborador")
                        .WithMany("ListaDependentes")
                        .HasForeignKey("ColaboradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Colaborador");
                });

            modelBuilder.Entity("APIRelacionamento.Models.ColaboradorModel", b =>
                {
                    b.Navigation("ListaDependentes");
                });

            modelBuilder.Entity("APIRelacionamento.Models.ViaCepModel", b =>
                {
                    b.Navigation("Colaboradores");
                });
#pragma warning restore 612, 618
        }
    }
}
