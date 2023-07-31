using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalI.Entities
{
    public class Carro
    {
        [Key]
        public int PkMatricula { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public string Observaciones { get; set; }
    }
}
