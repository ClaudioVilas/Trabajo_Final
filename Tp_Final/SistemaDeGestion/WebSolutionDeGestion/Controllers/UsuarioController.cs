using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;

namespace WebSolutionDeGestion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet (Name = "GetUsuarios")]
        public IEnumerable <UsuarioEntitie> Usuario()
        {
            return UsuarioBussiness.GetUsuarios().ToArray();
        }

        [HttpDelete(Name = "EliminarUsuario")]
        public void Delete([FromBody] int id)
        {
            UsuarioBussiness.EliminarUsuario(id);
        }

        [HttpPut(Name = "ModificarUsuario")]
        public void Put([FromBody] UsuarioEntitie usuario)
        {
            UsuarioBussiness.ModificarUsuario(usuario);
        }

        [HttpPost(Name = "AltaUsuario")]
        public void Post([FromBody] UsuarioEntitie usuario)
        {
            UsuarioBussiness.AltaUsuario(usuario);

        }
    }
}
