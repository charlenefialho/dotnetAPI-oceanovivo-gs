﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OceanoVivo.Data;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace OceanoVivo.Migrations
{
    [DbContext(typeof(OceanoVivoDbContext))]
    partial class OceanoVivoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OceanoVivo.Models.Categoria", b =>
                {
                    b.Property<int>("Id_Categoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Categoria"));

                    b.Property<string>("Familia")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Habitat")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Reino")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id_Categoria");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("OceanoVivo.Models.Deteccao", b =>
                {
                    b.Property<int>("Id_Deteccao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Deteccao"));

                    b.Property<DateTime>("Data_Deteccao")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("Id_Especie")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("Id_Localizacao")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("Id_Usuario")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Url_Imagem")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id_Deteccao");

                    b.HasIndex("Id_Especie");

                    b.HasIndex("Id_Localizacao");

                    b.HasIndex("Id_Usuario");

                    b.ToTable("Deteccoes");

                    b.HasData(
                        new
                        {
                            Id_Deteccao = 1,
                            Data_Deteccao = new DateTime(2024, 6, 7, 21, 36, 0, 195, DateTimeKind.Local).AddTicks(8323),
                            Id_Especie = 4,
                            Id_Localizacao = 1,
                            Id_Usuario = 2,
                            Url_Imagem = "https://exemplo.com/imagem.jpg"
                        });
                });

            modelBuilder.Entity("OceanoVivo.Models.Especie", b =>
                {
                    b.Property<int>("Id_Especie")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Especie"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<int>("Id_Categoria")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("Id_Situacao")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Nome_Cientifico")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Nome_Comum")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id_Especie");

                    b.HasIndex("Id_Categoria");

                    b.HasIndex("Id_Situacao");

                    b.ToTable("Especies");
                });

            modelBuilder.Entity("OceanoVivo.Models.Localizacao", b =>
                {
                    b.Property<int>("Id_Localizacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Localizacao"));

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<double>("Latitude")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<double>("Longitude")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<string>("Pais")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id_Localizacao");

                    b.ToTable("Localizacoes");
                });

            modelBuilder.Entity("OceanoVivo.Models.Ong", b =>
                {
                    b.Property<int>("Id_Ong")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Ong"));

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("NVARCHAR2(18)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id_Ong");

                    b.ToTable("Ongs");
                });

            modelBuilder.Entity("OceanoVivo.Models.OngDeteccao", b =>
                {
                    b.Property<int>("OngId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("DeteccaoId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("Id")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("OngId", "DeteccaoId");

                    b.HasIndex("DeteccaoId");

                    b.ToTable("OngDeteccao");
                });

            modelBuilder.Entity("OceanoVivo.Models.Situacao", b =>
                {
                    b.Property<int>("Id_Situacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Situacao"));

                    b.Property<int>("InvasoraInt")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("Invasora");

                    b.Property<int>("Risco_ExtincaoInt")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("Risco_Extincao");

                    b.HasKey("Id_Situacao");

                    b.ToTable("Situacoes");
                });

            modelBuilder.Entity("OceanoVivo.Models.Usuario", b =>
                {
                    b.Property<int>("Id_Usuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_Usuario"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id_Usuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("OceanoVivo.Models.Deteccao", b =>
                {
                    b.HasOne("OceanoVivo.Models.Especie", "Especie")
                        .WithMany("Deteccoes")
                        .HasForeignKey("Id_Especie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OceanoVivo.Models.Localizacao", "Localizacao")
                        .WithMany("Deteccoes")
                        .HasForeignKey("Id_Localizacao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OceanoVivo.Models.Usuario", "Usuario")
                        .WithMany("Deteccoes")
                        .HasForeignKey("Id_Usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Especie");

                    b.Navigation("Localizacao");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("OceanoVivo.Models.Especie", b =>
                {
                    b.HasOne("OceanoVivo.Models.Categoria", "Categoria")
                        .WithMany("Especies")
                        .HasForeignKey("Id_Categoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OceanoVivo.Models.Situacao", "Situacao")
                        .WithMany("Especies")
                        .HasForeignKey("Id_Situacao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Situacao");
                });

            modelBuilder.Entity("OceanoVivo.Models.OngDeteccao", b =>
                {
                    b.HasOne("OceanoVivo.Models.Deteccao", "Deteccao")
                        .WithMany("OngDeteccoes")
                        .HasForeignKey("DeteccaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OceanoVivo.Models.Ong", "Ong")
                        .WithMany("OngDeteccoes")
                        .HasForeignKey("OngId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Deteccao");

                    b.Navigation("Ong");
                });

            modelBuilder.Entity("OceanoVivo.Models.Categoria", b =>
                {
                    b.Navigation("Especies");
                });

            modelBuilder.Entity("OceanoVivo.Models.Deteccao", b =>
                {
                    b.Navigation("OngDeteccoes");
                });

            modelBuilder.Entity("OceanoVivo.Models.Especie", b =>
                {
                    b.Navigation("Deteccoes");
                });

            modelBuilder.Entity("OceanoVivo.Models.Localizacao", b =>
                {
                    b.Navigation("Deteccoes");
                });

            modelBuilder.Entity("OceanoVivo.Models.Ong", b =>
                {
                    b.Navigation("OngDeteccoes");
                });

            modelBuilder.Entity("OceanoVivo.Models.Situacao", b =>
                {
                    b.Navigation("Especies");
                });

            modelBuilder.Entity("OceanoVivo.Models.Usuario", b =>
                {
                    b.Navigation("Deteccoes");
                });
#pragma warning restore 612, 618
        }
    }
}
