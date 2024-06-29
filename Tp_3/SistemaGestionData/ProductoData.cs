using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionEntities;

namespace SistemaGestionData
{
    public class ProductoData
    {

        public static bool CreateProducto(ProductoEntitie producto)
        {
            string connectionString = @"Server = localhost\SQLEXPRESS; Database = SistemaGestion1; Trusted_Connection = True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Producto (id, descripciones, costo, precioventa, stock, idusuario) values(@id, @descripciones, @costo, @precioventa, @stock, @idusuario)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("id", producto.Id);
                command.Parameters.AddWithValue("descripciones", producto.Descripciones);
                command.Parameters.AddWithValue("costo", producto.Costo);
                command.Parameters.AddWithValue("precioventa", producto.PrecioVenta);
                command.Parameters.AddWithValue("stock", producto.Stock);
                command.Parameters.AddWithValue("idusuario", producto.IdUsuario);

                connection.Open();

                return command.ExecuteNonQuery() > 0;

            }
        }

        public static bool UpdateProducto(ProductoEntitie producto)
        {
            string connectionString = @"Server = localhost\SQLEXPRESS; Database = SistemaGestion1; Trusted_Connection = True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Producto SET id = @id, descripciones = @descripciones, costo = @costo, precioventa = @precioventa, stock = @stock, idusuario = @idusuario WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("ID", producto.Id);
                command.Parameters.AddWithValue("descripciones", producto.Descripciones);
                command.Parameters.AddWithValue("costo", producto.Costo);
                command.Parameters.AddWithValue("precioventa", producto.PrecioVenta);
                command.Parameters.AddWithValue("stock", producto.Stock);
                command.Parameters.AddWithValue("idusuario", producto.IdUsuario);
                connection.Open();

                return command.ExecuteNonQuery() > 0;

            }
        }

        public static bool DeleteProducto(int id)
        {
            string connectionString = @"Server = localhost\SQLEXPRESS; Database = SistemaGestion1; Trusted_Connection = True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Producto WHERE Id=@id";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.Parameters.AddWithValue("id", id);

                return command.ExecuteNonQuery() > 0;
            }
        }

        public static List<ProductoEntitie> GetProducto()
        {
            string connectionString = @"Server = localhost\SQLEXPRESS; Database = SistemaGestion1; Trusted_Connection = True;";

            List<ProductoEntitie> listaProducto = new List<ProductoEntitie>();

            string query = "SELECT * FROM Producto";
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
                                    var producto = new ProductoEntitie();

                                    producto.Id = Convert.ToInt32(dataReader["Id"]);
                                    producto.Descripciones = dataReader["Descripciones"].ToString();
                                    producto.Costo = Convert.ToInt32(dataReader["Costo"]);
                                    producto.PrecioVenta = Convert.ToInt32(dataReader["PrecioVenta"]);
                                    producto.Stock = Convert.ToInt32(dataReader["Stock"]);
                                    producto.IdUsuario = dataReader["IdUsuario"].ToString();
                                    listaProducto.Add(producto);
                                }
                            }
                            return listaProducto;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return listaProducto;
            }
        }
    }
}
