using System.Security.Cryptography.Pkcs;
using SistemaGestionData;
using SistemaGestionEntities;

namespace SistemaGestionUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargoUsuarios();
            cargoProductos();
            cargoProductosVendidos();
            cargoVentaData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        public void cargoUsuarios()
        {
            List<UsuarioEntitie> usuarios = UsuarioData.GetUsuarios();
            dgvSistemaGestionUI.AutoGenerateColumns = true;
            dgvSistemaGestionUI.DataSource = usuarios;

        }

        public void cargoProductos()
        {
            List<ProductoEntitie> producto = ProductoData.GetProducto();
            dgvSistemaGestionUI.AutoGenerateColumns = true;
            dgvSistemaGestionUI.DataSource = producto;
        }

        public void cargoProductosVendidos()
        {
            List<ProductoVendidoEntitie> productovendido = ProductoVendidoData.GetProductoVendido();
            dgvSistemaGestionUI.AutoGenerateColumns = true;
            dgvSistemaGestionUI.DataSource = productovendido;
        }

        public void cargoVentaData()
        {
            List<VentaEntitie> listaVenta = VentaData.GetVenta();
            dgvSistemaGestionUI.AutoGenerateColumns = true;
            dgvSistemaGestionUI.DataSource = listaVenta;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectValue = comboBox1.SelectedItem.ToString();

            if (selectValue == "Usuario")
            {
                cargoUsuarios();
            }
            if (selectValue == "Producto")
            {
                cargoProductos();
            }
            if (selectValue == "Producto Vendido")
            {
                cargoProductosVendidos();
            }
            if (selectValue == "Venta Data")
            {
                cargoVentaData();
            }
        }
    }
}
