using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionEntities;

namespace SistemaGestionData
{
    public class VentaData
    {
        public static List<VentaEntitie> GetVenta()
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=SistemaGestion1;Trusted_Connection=True;";

            List<VentaEntitie> listaVenta = new List<VentaEntitie>();

            string query = "SELECT * FROM Venta";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader dataReader = command.ExecuteReader())
                        {
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    var venta = new VentaEntitie();

                                    venta.Id = Convert.ToInt32(dataReader["Id"]);
                                    venta.Comentarios = dataReader["Comentarios"].ToString();
                                    venta.IdUsuario = Convert.ToInt32(dataReader["IdUsuario"]);

                                    listaVenta.Add(venta);

                                }

                            }
                            return listaVenta;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                return listaVenta;
            }

        }
        public static bool CreateVenta(VentaEntitie venta)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=SistemaGestion1;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Venta (id, comentarios, idusuario) values (@id, @comentarios, @idusuario)";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("id", venta.Id);
                command.Parameters.AddWithValue("comentarios", venta.Comentarios);
                command.Parameters.AddWithValue("idusuario", venta.IdUsuario);

                connection.Open();

                return command.ExecuteNonQuery() > 0;

            }
        }

        public static bool UpdateVenta(VentaEntitie venta)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=SistemaGestion1;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Venta SET id = @id, comentarios = @comentarios, idusuario = @idusuario WHERE Id = @id";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("id", venta.Id);
                command.Parameters.AddWithValue("comentarios", venta.Comentarios);
                command.Parameters.AddWithValue("idusuario", venta.IdUsuario);
                connection.Open();

                return command.ExecuteNonQuery() > 0;

            }
        }

        public static bool DeleteVenta(int id)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=SistemaGestion1;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Venta WHERE Id=@id";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.Parameters.AddWithValue("id", id);

                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}

