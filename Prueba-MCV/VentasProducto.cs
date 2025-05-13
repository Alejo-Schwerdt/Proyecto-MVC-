using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Controler;

namespace Prueba_MCV
{
    public partial class VentasProducto: UserControl
    {
        private ProductoController productoController = new ProductoController();
        private List<Producto> listaProductos = new List<Producto>();
        private List<DetalleVenta> detallesVenta = new List<DetalleVenta>();
        public event Action VolverAListar;

        public VentasProducto()
        {
            InitializeComponent();
            dgvDetalleVenta.AutoGenerateColumns = true;
            CargarProductos();
        }

        private void CargarProductos()
        {
            listaProductos = productoController.ObtenerTodosLosProductos();

            if (listaProductos == null || listaProductos.Count == 0)
            {
                MessageBox.Show("No hay productos disponibles.");
                return;
            }

            cmbProducto.DataSource = listaProductos;
            cmbProducto.DisplayMember = "nombreproducto"; 
            cmbProducto.ValueMember = "idproducto";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedItem == null || !int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Selecciona un producto y una cantidad válida.");
                return;
            }

            Producto producto = (Producto)cmbProducto.SelectedItem;

            if (cantidad > producto.stockproducto)
            {
                MessageBox.Show($"La cantidad solicitada ({cantidad}) supera el stock disponible ({producto.stockproducto}).");
                return;
            }

            DetalleVenta detalle = new DetalleVenta
            {
                IdProducto = producto.idproducto,
                Cantidad = cantidad,
                PrecioUnitario = producto.valorproducto,
                Producto = producto
            };

            detallesVenta.Add(detalle);
            ActualizarGrid();
        }

        private void ActualizarGrid()
        {
            dgvDetalleVenta.DataSource = null;
            dgvDetalleVenta.DataSource = detallesVenta.Select(d => new
            {
                Producto = d.Producto.nombreproducto,
                Cantidad = d.Cantidad,
                PrecioUnitario = d.PrecioUnitario,
                Subtotal = d.Cantidad * d.PrecioUnitario
            }).ToList();
        }

        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            if (detallesVenta.Count == 0)
            {
                MessageBox.Show("Agrega al menos un producto a la venta.");
                return;
            }

            Venta venta = new Venta
            {
                FechaVenta = DateTime.Now,
                Detalles = detallesVenta
            };

            venta.TotalVenta = detallesVenta.Sum(d => d.Cantidad * d.PrecioUnitario);

            VentaController controlador = new VentaController();
            bool resultado = controlador.RegistrarVenta(venta);

            if (resultado)
            {
                MessageBox.Show("Venta registrada con éxito.");
                detallesVenta.Clear();
                ActualizarGrid();
            }
            else
            {
                MessageBox.Show("Venta registrada con éxito.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            detallesVenta.Clear();
            ActualizarGrid();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            // Buscar el formulario contenedor (Form1)
            Form1 form = this.FindForm() as Form1;
            if (form != null)
            {
                // Llamar al método público de Form1 para volver al listado
                form.MostrarFormularioListar();
            }
        }
    }
}
