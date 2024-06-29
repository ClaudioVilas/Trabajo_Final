using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionEntities;

namespace SistemaGestionData
{
    public class ProductoVendidoData
    {
        public static List<ProductoVendidoEntitie> GetProductoVendido()
        {
            string connectionString = @"Server = localhost\SQLEXPRESS; Database = SistemaGestion1; Trusted_Connection = True;";

            List<ProductoVendidoEntitie> listaProductoVendido = new List<ProductoVendidoEntitie>();

            string query = "SELECT * FROM ProductoVendido";
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
                                    var productovendido = new ProductoVendidoEntitie();

                                    productovendido.Id = Convert.ToInt32(dataReader["Id"]);
                                    productovendido.Stock = Convert.ToInt32(dataReader["Stock"]);
                                    productovendido.IdProducto = Convert.ToInt32(dataReader["IdProducto"]);
                                    productovendido.IdVenta = Convert.ToInt32(dataReader["IdVenta"]);

                                    listaProductoVendido.Add(productovendido);

                                }

                            }
                            return listaProductoVendido;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                return listaProductoVendido;
            }

        }

        public static bool UpdateProductoVendido(ProductoVendidoEntitie productovendido)
        {
            string connectionString = @"Server = localhost\SQLEXPRESS; Database = SistemaGestion1; Trusted_Connection = True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE ProductoVendido SET id = @id, stock = @stock, idproducto = @idproducto, idventa = @idventa  WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("ID", productovendido.Id);
                command.Parameters.AddWithValue("stock", productovendido.Stock);
                command.Parameters.AddWithValue("idproducto", productovendido.IdProducto);
                command.Parameters.AddWithValue("idventa", productovendido.IdVenta);
                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }

        public static bool DeleteProductoVendido(int id)
        {
            string connectionString = @"Server = localhost\SQLEXPRESS; Database = SistemaGestion1; Trusted_Connection = True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM ProductoVendido WHERE Id=@id";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.Parameters.AddWithValue("id", id);

                return command.ExecuteNonQuery() > 0;
            }
        }

        public static bool CreateProductoVendido(ProductoVendidoEntitie productovendido)
        {
            string connectionString = @"Server = localhost\SQLEXPRESS; Database = SistemaGestion1; Trusted_Connection = True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO ProductoVendido (id, stock, idproducto, idventa) values(@id, @stock, @idproducto, @idventa)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("ID", productovendido.Id);
                command.Parameters.AddWithValue("stock", productovendido.Stock);
                command.Parameters.AddWithValue("idproducto", productovendido.IdProducto);
                command.Parameters.AddWithValue("idventa", productovendido.IdVenta);
                connection.Open();

                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}

