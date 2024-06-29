using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;

namespace WebSolutionDeGestion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [HttpGet(Name = "GetVenta")]
        public IEnumerable<VentaEntitie> Veenta()
        {
            return VentaBussiness.GetVenta().ToArray();
        }

        [HttpDelete(Name = "EliminarVenta")]
        public void Delete([FromBody] int id)
        {
            VentaBussiness.EliminarVenta(id);
        }

        [HttpPut(Name = "ModificarVenta")]
        public void Put([FromBody] VentaEntitie venta)
        {
            VentaBussiness.ModificarVenta(venta);
        }

        [HttpPost(Name = "AltaVenta")]
        public void Post([FromBody] VentaEntitie venta)
        {
            VentaBussiness.AltaVenta(venta);

        }

    }
}
