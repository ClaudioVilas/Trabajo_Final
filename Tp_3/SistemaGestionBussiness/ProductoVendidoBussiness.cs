using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionData;
using SistemaGestionEntities;

namespace SistemaGestionBussiness
{
    public class ProductoVendidoBussiness
    {
        public static List<ProductoVendidoEntitie> GetProductoVendido()
        {
            return ProductoVendidoData.GetProductoVendido();

        }
        public static void AltaProductoVendido(ProductoVendidoEntitie productovendido)
        {
            ProductoVendidoData.CreateProductoVendido(productovendido);
        }
        public static void EliminarProductoVendido(int id)
        {
            ProductoVendidoData.DeleteProductoVendido(id);
        }
        public static void ModificarProductoVendido(ProductoVendidoEntitie productovendido)
        {
            ProductoVendidoData.UpdateProductoVendido(productovendido);
        }
    }
}
