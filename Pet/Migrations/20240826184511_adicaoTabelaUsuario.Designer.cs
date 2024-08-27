﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Pet.Infrastructure.Data.Config;

#nullable disable

namespace Pet.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240826184511_adicaoTabelaUsuario")]
    partial class adicaoTabelaUsuario
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Pet.App.Entities.PgSQL.Matriz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Matriz");
                });

            modelBuilder.Entity("Pet.App.Entities.PgSQL.Ninhada", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("MatrizId")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("Quantidade")
                        .HasMaxLength(100)
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MatrizId");

                    b.ToTable("Ninhada");
                });

            modelBuilder.Entity("Pet.App.Entities.PgSQL.Ninhada", b =>
                {
                    b.HasOne("Pet.App.Entities.PgSQL.Matriz", "Matriz")
                        .WithMany("Ninhadas")
                        .HasForeignKey("MatrizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Matriz");
                });

            modelBuilder.Entity("Pet.App.Entities.PgSQL.Matriz", b =>
                {
                    b.Navigation("Ninhadas");
                });
#pragma warning restore 612, 618
        }
    }
}
