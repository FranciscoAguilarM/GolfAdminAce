using Microsoft.EntityFrameworkCore;
using ProyectoFinalI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalI.Context
{
    internal class ApplicationDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //AQUI VA CADENA DE CONEXION
            optionsBuilder.UseMySQL("Server=localhost; Database=ProyectoFinalV; User=root; Password=; ");
        }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Miembro> Miembros { get; set; }
        public DbSet<Carro> Carritos { get; set; }
        public DbSet<Asignar> AsignarCarritos { get; set; }
        public DbSet<Rol> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Rol 
            modelBuilder.Entity<Rol>().HasData(
    new Rol
    {
        PkRol = 1,
        Nombre = "Admin"
    },
    new Rol
    {
        PkRol = 2,
        Nombre = "Empleado"
    }

);
            #endregion

            #region Empleado
            modelBuilder.Entity<Empleado>().HasData(
           new Empleado
           {
               PkEmpleado = 1,
               Nombre = "Francisco",
               Apellido = "Aguilar",
               Usuario = "Frans",
               Contrasena = "1234",
               FKRol = 1
           },
           new Empleado
           {
               PkEmpleado = 3,
               Nombre = "Aaron",
               Apellido = "fermin",
               Usuario = "afer",
               Contrasena = "123",
               FKRol = 2
           },
          new Empleado
          {
              PkEmpleado = 4,
              Nombre = "tabata",
              Apellido = "jali",
              Usuario = "tabata",
              Contrasena = "123",
              FKRol = 2
          },
          new Empleado
          {
              PkEmpleado = 2,
              Nombre = "Angel",
              Apellido = "Palomec",
              Usuario = "sr.ph",
              Contrasena = "1234",
              FKRol = 2
          });
            #endregion

            #region Carrito
            modelBuilder.Entity<Carro>().HasData(
    new Carro
    {
        PkMatricula = 1,
        Modelo = "Alesso",
        Color="gris",
        Observaciones="Todo en orden"
    },
    new Carro
    {
        PkMatricula = 2,
        Modelo = "Onward",
        Color = "Azul",
        Observaciones = "Todo en orden"
    },
        new Carro
        {
            PkMatricula = 3,
            Modelo = "Alesso",
            Color = "Blanco",
            Observaciones = "En el taller"
        },
            new Carro
            {
                PkMatricula = 4,
                Modelo = "Onward",
                Color = "Rojo",
                Observaciones = "Todo En orden"
            },
        new Carro
        {
            PkMatricula = 5,
            Modelo = "rapss",
            Color = "Amarillo",
            Observaciones = "Fuera de Servicio"
        }

);
            #endregion

            #region Miembro 
            modelBuilder.Entity<Miembro>().HasData(
    new Miembro
    {
        PkMiembro = 1,
        Nombre = "Peter",
        Apellido = "Parker"
    },
    new Miembro
    {
        PkMiembro = 2,
        Nombre = "Franco",
        Apellido = "Escamilla"
    },
      new Miembro
      {
          PkMiembro = 3,
          Nombre = "Rudius",
          Apellido = "Greyrat"
      },
        new Miembro
        {
            PkMiembro = 4,
            Nombre = "Eris",
            Apellido = "BoreasGreyrat"
        }
);
            #endregion

        }








    }  
}
