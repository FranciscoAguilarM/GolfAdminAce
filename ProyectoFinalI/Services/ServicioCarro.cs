using ProyectoFinalI.Context;
using ProyectoFinalI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalI.Services
{
    internal class ServicioCarro
    {
        public void AgregarCarrito(Carro request)
        {
            try
            {
                using var _context = new ApplicationDBContext();
                Carro carrito = new()
                {
                    Modelo = request.Modelo,
                    Color = request.Color,
                    Observaciones = request.Observaciones,
                };
                _context.Carritos.Add(carrito);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception("Error:", ex);
            }
        }
        public List<Carro> VerCarrito()
        {
            try
            {
                var _context = new ApplicationDBContext();
                var versolicitudes2 = _context.Carritos.ToList();
                return versolicitudes2;
            }
            catch (Exception ex)
            {
                throw new Exception("Error:", ex);
            }
        }
        public void EditarCarrito(Carro request)
        {
            try
            {
                using ApplicationDBContext _context = new();
                var editarsolicitud = _context.Carritos.Where(s => s.PkMatricula == request.PkMatricula).First<Carro>();
                editarsolicitud.Modelo = request.Modelo;
                editarsolicitud.Color = request.Color;
                editarsolicitud.Observaciones = request.Observaciones;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error:", ex);
            }
        }
        public void EliminarCarrito(Carro request)
         {
             try
             {
                 using (var _context = new ApplicationDBContext())
                 {
                     var eliminarsolicitud = _context.Carritos.FirstOrDefault(s => s.PkMatricula == request.PkMatricula);
                     _context.Carritos.Remove(eliminarsolicitud);
                     _context.SaveChanges();
                 }
             }
             catch (Exception ex)
             {

                 throw new Exception("Error:", ex);
             }
         }
        public string ValidarAgregarCarrito(Carro request)
        {
            try
            {
                var _context = new ApplicationDBContext();
                var validarusuario = _context.Carritos.Where(s => s.Modelo == request.Modelo).ToList();
                return validarusuario.Count.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Error:", ex);
            }
        }

    }
}
