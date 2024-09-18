using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Veterinaria.Models
{
    internal class Cita
    {
        public int ID_Cita { get; set; }
        public int ID_Mascota { get; set; }
        public int ID_Veterinario { get; set; }
        public DateTime Fecha_Cita { get; set; }
        public string NombreMascota { get; set; }
        public string NombreVeterinario { get; set; }

        public override string ToString()
        {
            return $"{Fecha_Cita.ToShortDateString()} - {NombreMascota} - {NombreVeterinario}";
        }
    }
}
