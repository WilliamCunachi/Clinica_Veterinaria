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
    internal class PropietarioController
    {
        public static List<Propietario> ObtenerPropietarios()
        {
            var listaPropietarios = new List<Propietario>();

            using (var connection = Conexion.GetConnection())
            {
                string query = "SELECT * FROM Propietarios";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listaPropietarios.Add(new Propietario
                            {
                                ID_Propietario = reader.GetInt32(0),
                                Nombre = reader.GetString(1)
                            });
                        }
                    }
                }
            }

            return listaPropietarios;
        }
        public static void AgregarPropietario(Propietario propietario)
        {
            using (var connection = Conexion.GetConnection())
            {
                string query = "INSERT INTO Propietarios (Nombre) VALUES (@Nombre)";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Nombre", propietario.Nombre);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public static void ModificarPropietario(Propietario propietario)
        {
            using (var connection = Conexion.GetConnection())
            {
                string query = "UPDATE Propietarios SET Nombre = @Nombre WHERE ID_Propietario = @ID";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Nombre", propietario.Nombre);
                    cmd.Parameters.AddWithValue("@ID", propietario.ID_Propietario);
                    cmd.ExecuteNonQuery();
                }
            }
        }


        public static void EliminarPropietario(int idPropietario)
        {
            using (var connection = Conexion.GetConnection())
            {
                var query = "DELETE FROM Propietarios WHERE ID_Propietario = @ID_Propietario";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_Propietario", idPropietario);
                    command.ExecuteNonQuery();
                }
            }
        }


    }
}

