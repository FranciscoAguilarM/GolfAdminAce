using ProyectoFinalI.Context;
using ProyectoFinalI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalI.Services
{
    internal class ServicioMiembro
    {
        public void AgregarMiembro(Miembro request)
        {
            try
            {
                if (request != null)
                {
                    using (var _context = new ApplicationDBContext())
                    {
                        Miembro miembro = new Miembro()
                        {
                            Nombre = request.Nombre,
                            Apellido = request.Apellido,
                        };
                        _context.Miembros.Add(miembro);
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Bug: ", ex);
            }
        }

        public List<Miembro> VerMiembro()
        {
            try
            {
                var _context = new ApplicationDBContext();
                var versolicitudes3 = _context.Miembros.ToList();
                return versolicitudes3;
            }
            catch (Exception ex)
            {
                throw new Exception("Error:", ex);
            }
        }
        public void EditarMiembro(Miembro request)
        {
            try
            {
                using var _context = new ApplicationDBContext();
                var editarsolicitud = _context.Miembros.Where(s => s.PkMiembro == request.PkMiembro).First<Miembro>();
                editarsolicitud.Nombre = request.Nombre;
                editarsolicitud.Apellido = request.Apellido;

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error:", ex);
            }
        }
        public void EliminarMiembro(Miembro request)
         {
             try
             {
                 using (var _context = new ApplicationDBContext())
                 {
                     var eliminarsolicitud = _context.Miembros.FirstOrDefault(s => s.PkMiembro == request.PkMiembro);
                     _context.Miembros.Remove(eliminarsolicitud);
                     _context.SaveChanges();
                 }
             }
             catch (Exception ex)
             {

                 throw new Exception("Error:", ex);
             }
         }
        public string ValidarAgregarMiembro(Miembro request)
        {
            try
            {
                var _context = new ApplicationDBContext();
                var validarusuario = _context.Miembros.Where(s => s.Nombre == request.Nombre).ToList();
                return validarusuario.Count.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Error:", ex);
            }
        }
    }
}
