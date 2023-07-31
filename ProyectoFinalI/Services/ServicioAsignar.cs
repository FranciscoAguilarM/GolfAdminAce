using ProyectoFinalI.Context;
using ProyectoFinalI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalI.Services
{
    internal class ServicioAsignar
    {
           public void AgregarAsignar(Asignar request)
        {
            try
            {
                using var _context = new ApplicationDBContext();
                Asignar asignar = new()
                {
                    MatriculaCarrito = request.MatriculaCarrito,
                    nombreEmpleado = request.nombreEmpleado,
                    NombreMiembro = request.NombreMiembro,
                };
                _context.AsignarCarritos.Add(asignar);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Error:", ex);
            }
        }
        public List<Asignar> VerAsignar()
        {
            try
            {
                var _context = new ApplicationDBContext();
                var versolicitudes1 = _context.AsignarCarritos.ToList();
                return versolicitudes1;
            }
            catch (Exception ex)
            {
                throw new Exception("Error:", ex);
            }
        }
        public void EditarAsig(Asignar request)
        {
            try
            {
                using var _context = new ApplicationDBContext();
                var editarsolicitud = _context.AsignarCarritos.Where(s => s.IdAsig == request.IdAsig).First<Asignar>();
                editarsolicitud.MatriculaCarrito = request.MatriculaCarrito;
                editarsolicitud.nombreEmpleado = request.nombreEmpleado;
                editarsolicitud.NombreMiembro = request.NombreMiembro;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error:", ex);
            }
        }
          public void EliminarAsig(Asignar request)
           {
               try
               {
                   using (var _context = new ApplicationDBContext())
                   {
                       var eliminarsolicitud = _context.AsignarCarritos.FirstOrDefault(s => s.IdAsig == request.IdAsig);
                       _context.AsignarCarritos.Remove(eliminarsolicitud);
                       _context.SaveChanges();
                   }
               }
               catch (Exception ex)
               {

                   throw new Exception("Error:", ex);
               }
           }
        public string ValidarAgregarasig(Asignar request)
        {
            try
            {
                var _context = new ApplicationDBContext();
                var validarusuario = _context.AsignarCarritos.Where(s => s.MatriculaCarrito == request.MatriculaCarrito).ToList();
                return validarusuario.Count.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Error:", ex);
            }
        }
    }
}
