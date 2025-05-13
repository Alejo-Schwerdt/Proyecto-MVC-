using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using Controler;
using System.Linq;
using System.Data;

namespace Prueba_MCV
{
    public partial class DetalleVentasProductos : Form
    {
        private VentaController ventaController = new VentaController();

        public DetalleVentasProductos()
        {
            InitializeComponent();
            CargarVentas();
        }
        private void DetalleVentasProductos_Load(object sender, EventArgs e)
        {
            string query = @"
        SELECT v.IdVenta, v.FechaVenta, v.TotalVenta, p.NombreProducto, dv.Cantidad, dv.PrecioUnitario
        FROM Ventas v
        JOIN DetalleVenta dv ON v.IdVenta = dv.IdVenta
        JOIN Productos p ON dv.IdProducto = p.IdProducto";

            DataTable tabla = Database.Select(query); // Usa tu método para ejecutar SELECT

            dgvVentas.DataSource = tabla;
        }

        private void CargarVentas()
        {
            List<Venta> ventas = ventaController.ObtenerTodasLasVentas(); // Este método debe existir en tu controlador

            dgvVentas.DataSource = ventas.Select(v => new
            {
                v.IDVenta,
                Fecha = v.FechaVenta.ToString("g"),
                Total = v.TotalVenta
            }).ToList();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra este formulario y vuelve al principal
        }
        


    }
}
