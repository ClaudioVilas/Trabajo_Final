using SistemaGestionEntities;
using System.Data.SqlClient;

namespace SistemaGestionData
{

    public class UsuarioData
    {
        public static bool CreateUsuario(UsuarioEntitie usuario)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=SistemaGestion1;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Usuario (nombre, apellido, nombreUsuario, contraseña, mail) values(@nombre, @apellido, @nombreUsuario, @contraseña, @mail)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("nombre", usuario.Nombre);
                command.Parameters.AddWithValue("apellido", usuario.Apellido);
                command.Parameters.AddWithValue("nombreUsuario", usuario.NombreUsuario);
                command.Parameters.AddWithValue("contraseña", usuario.Contraseña);
                command.Parameters.AddWithValue("mail", usuario.Mail);

                connection.Open();

                return command.ExecuteNonQuery() > 0;

            }
        }

        public static bool UpdateUsuario(UsuarioEntitie usuario)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=SistemaGestion1;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Usuario SET nombre = @nombre, apellido = @apellido, nombreUsuario = @nombreUsuario, contraseña = @contraseña, mail = @mail WHERE Id = @id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("nombre", usuario.Nombre);
                command.Parameters.AddWithValue("apellido", usuario.Apellido);
                command.Parameters.AddWithValue("nombreUsuario", usuario.NombreUsuario);
                command.Parameters.AddWithValue("contraseña", usuario.Contraseña);
                command.Parameters.AddWithValue("mail", usuario.Mail);
                command.Parameters.AddWithValue("id", usuario.Id);

                connection.Open();

                return command.ExecuteNonQuery() > 0;

            }
        }

        public static bool DeleteUsuario(int id)
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=SistemaGestion1;Trusted_Connection=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Usuario WHERE Id=@id";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                command.Parameters.AddWithValue("id", id);

                return command.ExecuteNonQuery() > 0;
            }
        }

        public static List<UsuarioEntitie> GetUsuarios()
        {
            string connectionString = @"Server=localhost\SQLEXPRESS;Database=SistemaGestion1;Trusted_Connection=True;";

            List<UsuarioEntitie> listaUsuario = new List<UsuarioEntitie>();

            string query = "SELECT * FROM Usuario";
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
                                    var usuario = new UsuarioEntitie();

                                    usuario.Id = Convert.ToInt32(dataReader["Id"]);
                                    usuario.Nombre = dataReader["Nombre"].ToString();
                                    usuario.Apellido = dataReader["Apellido"].ToString();
                                    usuario.NombreUsuario = dataReader["NombreUsuario"].ToString();
                                    usuario.Contraseña = dataReader["Contraseña"].ToString();
                                    usuario.Mail = dataReader["mail"].ToString();

                                    listaUsuario.Add(usuario);

                                }

                            }
                            return listaUsuario;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                return listaUsuario;
            }

        }
    }
}
