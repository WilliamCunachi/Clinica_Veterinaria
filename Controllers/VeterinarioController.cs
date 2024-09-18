using Clinica_Veterinaria.Config;
using Clinica_Veterinaria.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica_Veterinaria.Controllers
{
    internal class VeterinarioController
    {
        public static List<Veterinario> ObtenerVeterinarios()
        {
            var veterinarios = new List<Veterinario>();

            using (var connection = Conexion.GetConnection())
            {
                var query = "SELECT ID_Veterinario, Nombre FROM Veterinarios";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var veterinario = new Veterinario
                            {
                                ID_Veterinario = (int)reader["ID_Veterinario"],
                                Nombre = reader["Nombre"].ToString()
                            };
                            veterinarios.Add(veterinario);
                        }
                    }
                }
            }

            return veterinarios;
        }

        public static void AgregarVeterinario(Veterinario veterinario)
        {
            using (var connection = Conexion.GetConnection())
            {
                var query = "INSERT INTO Veterinarios (Nombre) VALUES (@Nombre)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", veterinario.Nombre);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void ModificarVeterinario(Veterinario veterinario)
        {
            using (var connection = Conexion.GetConnection())
            {
                var query = "UPDATE Veterinarios SET Nombre = @Nombre WHERE ID_Veterinario = @ID_Veterinario";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", veterinario.Nombre);
                    command.Parameters.AddWithValue("@ID_Veterinario", veterinario.ID_Veterinario);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void EliminarVeterinario(int idVeterinario)
        {
            using (var connection = Conexion.GetConnection())
            {
                var query = "DELETE FROM Veterinarios WHERE ID_Veterinario = @ID_Veterinario";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_Veterinario", idVeterinario);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
