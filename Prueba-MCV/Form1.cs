using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prueba_MCV
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Crear una nueva instancia de ListarPersona
            ListarProducto listar = new ListarProducto();

            // Mostrar el UserControl en el panel
            MostrarControl(listar);
        }

        private void MostrarControl(UserControl control)
        {
            panel1.Controls.Clear();  // Limpiar cualquier control previo
            control.Dock = DockStyle.Fill;  // Ajustar el UserControl al tamaño del panel
            panel1.Controls.Add(control);  // Añadir el UserControl al panel
        }

        public void MostrarFormularioAgregarModificar(Producto producto = null)
        {
            panel1.Controls.Clear();
            var uc = new AgregarModificarProducto();
            uc.Dock = DockStyle.Fill;
            uc.VolverAListar += () =>
            {
                MostrarFormularioListar(); // Método que carga el ListarProducto
            };
            uc.Inicializar(producto);
            panel1.Controls.Add(uc);
        }
        public void MostrarFormularioVentasProducto()
        {
            panel1.Controls.Clear();
            var uc = new VentasProducto();
            uc.Dock = DockStyle.Fill;

            // También podés suscribirte a eventos de este control si es necesario
            panel1.Controls.Add(uc);
        }
        public void MostrarFormularioDetalleVentasProductos()
        {
            var detalleForm = new DetalleVentasProductos(); // es un Form
            detalleForm.ShowDialog(); // o detalleForm.Show();
        }

        public void MostrarFormularioListar()
        {
            panel1.Controls.Clear();
            var uc = new ListarProducto();
            uc.Dock = DockStyle.Fill;

            // También podés suscribirte a eventos de este control si es necesario
            panel1.Controls.Add(uc);
        }
       
    }
}
