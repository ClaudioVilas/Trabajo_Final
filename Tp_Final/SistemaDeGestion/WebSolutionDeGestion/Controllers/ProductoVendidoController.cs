using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaGestionBussiness;
using SistemaGestionEntities;

namespace WebSolutionDeGestion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet(Name = "GetProductoVendido")]
        public IEnumerable<ProductoVendidoEntitie> ProductoVendido()
        {
            return ProductoVendidoBussiness.GetProductoVendido().ToArray();
        }

        [HttpDelete(Name = "EliminarProductoVendido")]
        public void Delete([FromBody] int id)
        {
            ProductoVendidoBussiness.EliminarProductoVendido(id);
        }


        [HttpPut(Name = "ModificarProductoVendido")]
        public void Put([FromBody] ProductoVendidoEntitie productovendido)
        {
            ProductoVendidoBussiness.ModificarProductoVendido(productovendido);
        }


        [HttpPost(Name = "AltaProductoVendido")]
        public void Post([FromBody] ProductoVendidoEntitie productovendido)
        {
            ProductoVendidoBussiness.AltaProductoVendido(productovendido);

        }

    }
}
