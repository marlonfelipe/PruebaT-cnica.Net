﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegistroUsuarios.Models;

#nullable disable

namespace RegistroUsuarios.Migrations
{
    [DbContext(typeof(DbtestContext))]
    [Migration("20230616165359_actualizacion2")]
    partial class actualizacion2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RegistroUsuarios.Models.Empleado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("BonoDecreto")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("BonoPaternidad")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("CantidadHijos")
                        .HasColumnType("int");

                    b.Property<string>("DPI")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("FechaCreacion")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<decimal?>("Igss")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Irtra")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal?>("SalarioBase")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("SalarioLiquido")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("SalarioTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Usuario")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Empleado");
                });

            modelBuilder.Entity("RegistroUsuarios.Models.Palindromo", b =>
                {
                    b.Property<string>("Texto")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Texto");

                    b.ToTable("Palindromo");
                });

            modelBuilder.Entity("RegistroUsuarios.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Clave")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Correo")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NombreUsuario")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdUsuario")
                        .HasName("PK__USUARIO__5B65BF977B5B8FC4");

                    b.ToTable("USUARIO", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
