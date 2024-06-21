﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Senai.Api.Data;

#nullable disable

namespace Senai.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240619200613_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Senai.Core.Models.Cars", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Cor")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)");

                    b.Property<string>("Placa")
                        .HasMaxLength(7)
                        .HasColumnType("character varying(7)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(160)
                        .HasColumnType("character varying(160)");

                    b.HasKey("Id");

                    b.ToTable("Carros", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
