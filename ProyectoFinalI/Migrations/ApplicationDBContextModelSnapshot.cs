﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoFinalI.Context;

namespace ProyectoFinalI.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ProyectoFinalI.Entities.Asignar", b =>
                {
                    b.Property<int>("IdAsig")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("MatriculaCarrito")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NombreMiembro")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("nombreEmpleado")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IdAsig");

                    b.ToTable("AsignarCarritos");
                });

            modelBuilder.Entity("ProyectoFinalI.Entities.Carro", b =>
                {
                    b.Property<int>("PkMatricula")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Observaciones")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PkMatricula");

                    b.ToTable("Carritos");

                    b.HasData(
                        new
                        {
                            PkMatricula = 1,
                            Color = "gris",
                            Modelo = "Alesso",
                            Observaciones = "Todo en orden"
                        },
                        new
                        {
                            PkMatricula = 2,
                            Color = "Azul",
                            Modelo = "Onward",
                            Observaciones = "Todo en orden"
                        },
                        new
                        {
                            PkMatricula = 3,
                            Color = "Blanco",
                            Modelo = "Alesso",
                            Observaciones = "En el taller"
                        },
                        new
                        {
                            PkMatricula = 4,
                            Color = "Rojo",
                            Modelo = "Onward",
                            Observaciones = "Todo En orden"
                        },
                        new
                        {
                            PkMatricula = 5,
                            Color = "Amarillo",
                            Modelo = "rapss",
                            Observaciones = "Fuera de Servicio"
                        });
                });

            modelBuilder.Entity("ProyectoFinalI.Entities.Empleado", b =>
                {
                    b.Property<int>("PkEmpleado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("FKRol")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PkEmpleado");

                    b.HasIndex("FKRol");

                    b.ToTable("Empleados");

                    b.HasData(
                        new
                        {
                            PkEmpleado = 1,
                            Apellido = "Aguilar",
                            Contrasena = "1234",
                            FKRol = 1,
                            Nombre = "Francisco",
                            Usuario = "Frans"
                        },
                        new
                        {
                            PkEmpleado = 3,
                            Apellido = "fermin",
                            Contrasena = "123",
                            FKRol = 2,
                            Nombre = "Aaron",
                            Usuario = "afer"
                        },
                        new
                        {
                            PkEmpleado = 4,
                            Apellido = "jali",
                            Contrasena = "123",
                            FKRol = 2,
                            Nombre = "tabata",
                            Usuario = "tabata"
                        },
                        new
                        {
                            PkEmpleado = 2,
                            Apellido = "Palomec",
                            Contrasena = "1234",
                            FKRol = 2,
                            Nombre = "Angel",
                            Usuario = "sr.ph"
                        });
                });

            modelBuilder.Entity("ProyectoFinalI.Entities.Miembro", b =>
                {
                    b.Property<int>("PkMiembro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PkMiembro");

                    b.ToTable("Miembros");

                    b.HasData(
                        new
                        {
                            PkMiembro = 1,
                            Apellido = "Parker",
                            Nombre = "Peter"
                        },
                        new
                        {
                            PkMiembro = 2,
                            Apellido = "Escamilla",
                            Nombre = "Franco"
                        },
                        new
                        {
                            PkMiembro = 3,
                            Apellido = "Greyrat",
                            Nombre = "Rudius"
                        },
                        new
                        {
                            PkMiembro = 4,
                            Apellido = "BoreasGreyrat",
                            Nombre = "Eris"
                        });
                });

            modelBuilder.Entity("ProyectoFinalI.Entities.Rol", b =>
                {
                    b.Property<int>("PkRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PkRol");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            PkRol = 1,
                            Nombre = "Admin"
                        },
                        new
                        {
                            PkRol = 2,
                            Nombre = "Empleado"
                        });
                });

            modelBuilder.Entity("ProyectoFinalI.Entities.Empleado", b =>
                {
                    b.HasOne("ProyectoFinalI.Entities.Rol", "Roles")
                        .WithMany()
                        .HasForeignKey("FKRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
