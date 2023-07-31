using Microsoft.EntityFrameworkCore;
using ProyectoFinalI.Context;
using ProyectoFinalI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalI.Services
{
    internal class ServicioEmpleado
    {
        
        public void AgregarEmpleado(Empleado request)
        {
            try
            {
                using var _context = new ApplicationDBContext();
                Empleado empleado = new()
                {
                    Nombre = request.Nombre,
                    Apellido = request.Apellido,
                    Usuario = request.Usuario,
                    Contrasena = request.Contrasena,
                   FKRol = request.FKRol=2,
                };
                _context.Empleados.Add(empleado);
               _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Error:", ex);
            }
        }
        public List<Empleado> VerEmpleado()
        {
            try
            {
                var _context = new ApplicationDBContext();
                var versolicitudes = _context.Empleados.Include(x=>x.Roles).ToList();
                return versolicitudes;
            }
            catch (Exception ex)
            {
                throw new Exception("Error:", ex);
            }
        }
        public List<Rol> GetRoles()
        {
            try
            {
                using (var _context = new ApplicationDBContext())
                {
                    List<Rol> roles = _context.Roles.ToList();

                    return roles;
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Succedio un error" + ex.Message);
            }
        }
       /* public int ObtenerIdRolPorNombre(string nombreRol)
        {
            using var _context = new ApplicationDBContext();
            var rol = _context.Roles.FirstOrDefault(r => r.Nombre == nombreRol);
            return rol != null ? rol.PkRol : 0;
        }*/

        
        public void EditarEmpleado(Empleado request)
        {
            try
            {
                using ApplicationDBContext _context = new();
                var editarempleado = _context.Empleados.Where(s => s.PkEmpleado == request.PkEmpleado).First<Empleado>();
                editarempleado.Nombre = request.Nombre;
                editarempleado.Apellido = request.Apellido;
                editarempleado.Usuario = request.Usuario;
                editarempleado.Contrasena = request.Contrasena;
                editarempleado.FKRol = request.FKRol;
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception("Error al editar el empleado: " + ex.Message);
            }
        }

        public void EliminarEmpleado(Empleado request)
            {
                try
                {
                    using (var _context = new ApplicationDBContext())
                    {
                        var eliminarsolicitud = _context.Empleados.FirstOrDefault(s => s.PkEmpleado == request.PkEmpleado);
                        _context.Empleados.Remove(eliminarsolicitud);
                        _context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {

                    throw new Exception("Error:", ex);
                }
            }
        public string ValidarAgregarEmpleado(Empleado request)
        {
            try
            {
                var _context = new ApplicationDBContext();
                var validarusuario = _context.Empleados.Where(s => s.Nombre == request.Nombre).ToList();
                return validarusuario.Count.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Error:", ex);
            }
        }
        public Empleado Login(string UserName, string Password)
        {
            try
            {
                using (var _context = new ApplicationDBContext())
                {
                    var empleado = _context.Empleados.Include(y => y.Roles).FirstOrDefault(x => x.Usuario == UserName && x.Contrasena == Password);


                    return empleado;

                }

            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
