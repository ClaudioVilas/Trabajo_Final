using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionData;
using SistemaGestionEntities;

namespace SistemaGestionBussiness
{
    public class ProductoBussiness
    {
        public static void AltaProducto(ProductoEntitie producto)
        {
            ProductoData.CreateProducto(producto);
        }

        public static List<ProductoEntitie> GetProducto()
        {
            return ProductoData.GetProducto();
        }

        public static void EliminarProducto(int id)
        {
            ProductoData.DeleteProducto(id);
        }

        public static void ModificarProducto(ProductoEntitie producto)
        {
            ProductoData.UpdateProducto(producto);
        }

    }
}
