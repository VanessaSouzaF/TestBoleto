﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TesteBoleto.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240201010559_AddUsersTable")]
    partial class AddUsersTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Banco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CodigoBanco")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NomeBanco")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("PercentualJuros")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Bancos");
                });

            modelBuilder.Entity("Boleto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BancoId")
                        .HasColumnType("integer");

                    b.Property<string>("CPFCNPJBeneficiario")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CPFCNPJPagador")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NomeBeneficiario")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NomePagador")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Observacao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Valor")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("BancoId");

                    b.ToTable("Boletos");
                });

            modelBuilder.Entity("UserModel", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Boleto", b =>
                {
                    b.HasOne("Banco", "Banco")
                        .WithMany("Boletos")
                        .HasForeignKey("BancoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Banco");
                });

            modelBuilder.Entity("Banco", b =>
                {
                    b.Navigation("Boletos");
                });
#pragma warning restore 612, 618
        }
    }
}
