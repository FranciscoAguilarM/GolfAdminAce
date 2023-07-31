using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalI.Entities
{
    public class Miembro
    {
        [Key]
        public int PkMiembro { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
