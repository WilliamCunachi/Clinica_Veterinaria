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
    internal class MascotaController
    {
        public static List<Mascota> ObtenerMascotas()
        {
            var mascotas = new List<Mascota>();

            using (var connection = Conexion.GetConnection())
            {
                var query = "SELECT ID_Mascota, Nombre, ID_Propietario FROM Mascotas";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var mascota = new Mascota
                            {
                                ID_Mascota = (int)reader["ID_Mascota"],
                                Nombre = reader["Nombre"].ToString(),
                                ID_Propietario = (int)reader["ID_Propietario"]
                            };
                            mascotas.Add(mascota);
                        }
                    }
                }
            }

            return mascotas;
        }

        public static void AgregarMascota(Mascota mascota)
        {
            using (var connection = Conexion.GetConnection())
            {
                var query = "INSERT INTO Mascotas (Nombre, ID_Propietario) VALUES (@Nombre, @ID_Propietario)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", mascota.Nombre);
                    command.Parameters.AddWithValue("@ID_Propietario", mascota.ID_Propietario);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void ModificarMascota(Mascota mascota)
        {
            using (var connection = Conexion.GetConnection())
            {
                var query = "UPDATE Mascotas SET Nombre = @Nombre, ID_Propietario = @ID_Propietario WHERE ID_Mascota = @ID_Mascota";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Nombre", mascota.Nombre);
                    command.Parameters.AddWithValue("@ID_Propietario", mascota.ID_Propietario);
                    command.Parameters.AddWithValue("@ID_Mascota", mascota.ID_Mascota);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void EliminarMascota(int idMascota)
        {
            using (var connection = Conexion.GetConnection())
            {
                var query = "DELETE FROM Mascotas WHERE ID_Mascota = @ID_Mascota";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_Mascota", idMascota);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
