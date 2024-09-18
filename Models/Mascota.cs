using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Veterinaria.Models
{
    internal class Mascota
    {
        public int ID_Mascota { get; set; }
        public string Nombre { get; set; }
        public int ID_Propietario { get; set; }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
