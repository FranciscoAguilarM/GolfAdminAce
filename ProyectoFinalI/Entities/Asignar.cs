using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalI.Entities
{
    public class Asignar
    {
        [Key]
        public int IdAsig { get; set; }
        public string MatriculaCarrito { get; set; }
        public string NombreMiembro { get; set; }
        public string nombreEmpleado { get; set; }
    }
}
