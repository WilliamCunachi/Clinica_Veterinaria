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
    internal class CitasController
    {
        public static List<Cita> ObtenerCitas()
        {
            var citas = new List<Cita>();

            using (var connection = Conexion.GetConnection())
            {
                var query = @"
                    SELECT C.ID_Cita, C.Fecha_Cita, M.Nombre AS NombreMascota, V.Nombre AS NombreVeterinario
                    FROM Citas C
                    INNER JOIN Mascotas M ON C.ID_Mascota = M.ID_Mascota
                    INNER JOIN Veterinarios V ON C.ID_Veterinario = V.ID_Veterinario";

                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var cita = new Cita
                            {
                                ID_Cita = (int)reader["ID_Cita"],
                                Fecha_Cita = (DateTime)reader["Fecha_Cita"],
                                NombreMascota = reader["NombreMascota"].ToString(),
                                NombreVeterinario = reader["NombreVeterinario"].ToString()
                            };
                            citas.Add(cita);
                        }
                    }
                }
            }

            return citas;
        }

        public static void AgregarCita(Cita cita)
        {
            using (var connection = Conexion.GetConnection())
            {
                var query = "INSERT INTO Citas (ID_Mascota, ID_Veterinario, Fecha_Cita) VALUES (@ID_Mascota, @ID_Veterinario, @Fecha_Cita)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_Mascota", cita.ID_Mascota);
                    command.Parameters.AddWithValue("@ID_Veterinario", cita.ID_Veterinario);
                    command.Parameters.AddWithValue("@Fecha_Cita", cita.Fecha_Cita);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void ModificarCita(Cita cita)
        {
            using (var connection = Conexion.GetConnection())
            {
                var query = "UPDATE Citas SET ID_Mascota = @ID_Mascota, ID_Veterinario = @ID_Veterinario, Fecha_Cita = @Fecha_Cita WHERE ID_Cita = @ID_Cita";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_Cita", cita.ID_Cita);
                    command.Parameters.AddWithValue("@ID_Mascota", cita.ID_Mascota);
                    command.Parameters.AddWithValue("@ID_Veterinario", cita.ID_Veterinario);
                    command.Parameters.AddWithValue("@Fecha_Cita", cita.Fecha_Cita);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void EliminarCita(int idCita)
        {
            using (var connection = Conexion.GetConnection())
            {
                var query = "DELETE FROM Citas WHERE ID_Cita = @ID_Cita";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_Cita", idCita);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
