using Clinica_Veterinaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Veterinaria.Controllers
{
    internal class UsuarioController
    {
        public static UsuarioModel AutenticarUsuario(string usuario, string contraseña)
        {
            return UsuarioModel.ValidarUsuario(usuario, contraseña);
        }
    }
}
