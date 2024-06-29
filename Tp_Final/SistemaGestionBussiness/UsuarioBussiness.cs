using SistemaGestionData;
using SistemaGestionEntities;


namespace SistemaGestionBussiness
{
    public class UsuarioBussiness
    {
        public static void AltaUsuario(UsuarioEntitie usuario)
        {
            UsuarioData.CreateUsuario(usuario);
        }

        public static void EliminarUsuario(int id)
        {
            UsuarioData.DeleteUsuario(id);
        }

        public static List<UsuarioEntitie> GetUsuarios()
        {
            return UsuarioData.GetUsuarios();
        }

        public static void ModificarUsuario(UsuarioEntitie usuario)
        {
            UsuarioData.UpdateUsuario(usuario);
        }
    }
}
