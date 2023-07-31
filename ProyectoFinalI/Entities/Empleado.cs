using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalI.Entities
{
    public class Empleado
    {
        [Key]
        public int PkEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }

        [ForeignKey("Roles")]
        public int? FKRol { get; set; }
        public Rol Roles { get; set; }
    }
}
