using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionData;
using SistemaGestionEntities;

namespace SistemaGestionBussiness
{
    public class VentaBussiness
    {
        public static List<VentaEntitie> GetVenta()
        {
            return VentaData.GetVenta();

        }

        public static void AltaVenta(VentaEntitie venta)
        {
            VentaData.CreateVenta(venta);
        }

        public static void EliminarVenta(int id)
        {
            VentaData.DeleteVenta(id);
        }

        public static void ModificarVenta(VentaEntitie venta)
        {
            VentaData.UpdateVenta(venta);
        }


    }
}
