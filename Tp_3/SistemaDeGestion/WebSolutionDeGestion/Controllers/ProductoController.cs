using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;

namespace WebSolutionDeGestion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet(Name = "GetProducto")]
        public IEnumerable<ProductoEntitie> Producto()
        {
            return ProductoBussiness.GetProducto().ToArray();
        }

        [HttpDelete(Name = "EliminarProducto")]
        public void Delete([FromBody] int id)
        {
            ProductoBussiness.EliminarProducto(id);
        }

        [HttpPut(Name = "ModificarProducto")]
        public void Put([FromBody] ProductoEntitie producto)
        {
            ProductoBussiness.ModificarProducto(producto);
        }

        [HttpPost(Name = "AltaProducto")]
        public void Post([FromBody] ProductoEntitie producto)
        {
            ProductoBussiness.AltaProducto(producto);

        }
    }
}
