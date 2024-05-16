﻿// <auto-generated />
using System;
using LogicaDatos.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LogicaDatos.Migrations
{
    [DbContext(typeof(LibreriaContext))]
    [Migration("20240515205916_Pedidos fluentapi")]
    partial class Pedidosfluentapi
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LogicaNegocio.Dominio.Articulo", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("codigoProveedor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("MinLength", 10);

                    b.Property<string>("descripcion")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasAnnotation("MinLength", 10);

                    b.Property<decimal>("precioPublico")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("stock")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Articulos");
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Cliente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("RUT")
                        .HasColumnType("int");

                    b.Property<string>("calle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ciudad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("distancia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("numPuerta")
                        .HasColumnType("int");

                    b.Property<string>("razonSocial")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Linea", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("Pedidoid")
                        .HasColumnType("int");

                    b.Property<int>("articuloid")
                        .HasColumnType("int");

                    b.Property<int>("cantUnidades")
                        .HasColumnType("int");

                    b.Property<decimal>("preUnitarioVigente")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("id");

                    b.HasIndex("Pedidoid");

                    b.HasIndex("articuloid");

                    b.ToTable("Lineas", t =>
                        {
                            t.HasCheckConstraint("CHK_cantUnidades_mayor_cero", "cantUnidades > 0");
                        });
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Pedido", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<decimal>("IVA")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<bool>("activo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("fechaPedido")
                        .HasColumnType("datetime2")
                        .HasColumnName("FechaPedido");

                    b.Property<DateTime>("fechaPrometida")
                        .HasColumnType("datetime2");

                    b.Property<int>("idCliente")
                        .HasColumnType("int");

                    b.Property<decimal>("recarga")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("total")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("id");

                    b.HasIndex("idCliente");

                    b.ToTable("Pedido", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("passwordHash")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("id");

                    b.HasIndex("email")
                        .IsUnique();

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.PedidoComun", b =>
                {
                    b.HasBaseType("LogicaNegocio.Dominio.Pedido");

                    b.Property<decimal>("distancia")
                        .HasColumnType("decimal(18, 2)");

                    b.ToTable("PedidoComun", (string)null);
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.PedidoExpress", b =>
                {
                    b.HasBaseType("LogicaNegocio.Dominio.Pedido");

                    b.Property<decimal>("plazoDias")
                        .HasColumnType("decimal(18, 2)");

                    b.ToTable("PedidoExpress", null, t =>
                        {
                            t.HasCheckConstraint("CHK_PedidoExpress_plazoDias", "plazoDias BETWEEN 1 AND 5");
                        });
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Linea", b =>
                {
                    b.HasOne("LogicaNegocio.Dominio.Pedido", null)
                        .WithMany("lineas")
                        .HasForeignKey("Pedidoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LogicaNegocio.Dominio.Articulo", "articulo")
                        .WithMany()
                        .HasForeignKey("articuloid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("articulo");
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Pedido", b =>
                {
                    b.HasOne("LogicaNegocio.Dominio.Cliente", "cliente")
                        .WithMany()
                        .HasForeignKey("idCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Pedido_Cliente");

                    b.Navigation("cliente");
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.PedidoComun", b =>
                {
                    b.HasOne("LogicaNegocio.Dominio.Pedido", null)
                        .WithOne()
                        .HasForeignKey("LogicaNegocio.Dominio.PedidoComun", "id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.PedidoExpress", b =>
                {
                    b.HasOne("LogicaNegocio.Dominio.Pedido", null)
                        .WithOne()
                        .HasForeignKey("LogicaNegocio.Dominio.PedidoExpress", "id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LogicaNegocio.Dominio.Pedido", b =>
                {
                    b.Navigation("lineas");
                });
#pragma warning restore 612, 618
        }
    }
}