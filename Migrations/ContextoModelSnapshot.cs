﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Parcial2AP1.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("Producido", b =>
                {
                    b.Property<int>("ProducidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Concepto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.HasKey("ProducidoId");

                    b.ToTable("Producido");
                });

            modelBuilder.Entity("ProducidoDetalle", b =>
                {
                    b.Property<int>("DetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProducidoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DetalleId");

                    b.HasIndex("ProducidoId");

                    b.ToTable("ProducidoDetalle");
                });

            modelBuilder.Entity("Producto", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Costo")
                        .HasColumnType("REAL");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<int>("Existencia")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Precio")
                        .HasColumnType("REAL");

                    b.HasKey("ProductoId");

                    b.ToTable("Producto");

                    b.HasData(
                        new
                        {
                            ProductoId = 1,
                            Costo = 20.0,
                            Descripcion = "Mani Japones",
                            Existencia = 12,
                            Precio = 35.0
                        },
                        new
                        {
                            ProductoId = 2,
                            Costo = 50.0,
                            Descripcion = "Pistacho",
                            Existencia = 10,
                            Precio = 75.0
                        },
                        new
                        {
                            ProductoId = 3,
                            Costo = 60.0,
                            Descripcion = "Cajuil salado",
                            Existencia = 5,
                            Precio = 90.0
                        },
                        new
                        {
                            ProductoId = 4,
                            Costo = 33.0,
                            Descripcion = "Almendras",
                            Existencia = 2,
                            Precio = 50.0
                        },
                        new
                        {
                            ProductoId = 5,
                            Costo = 200.0,
                            Descripcion = "Sobre Mixto",
                            Existencia = 0,
                            Precio = 300.0
                        });
                });

            modelBuilder.Entity("ProducidoDetalle", b =>
                {
                    b.HasOne("Producido", null)
                        .WithMany("ProducidoDetalle")
                        .HasForeignKey("ProducidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Producido", b =>
                {
                    b.Navigation("ProducidoDetalle");
                });
#pragma warning restore 612, 618
        }
    }
}
