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
    public partial class ListarProducto: UserControl
    {

        private ProductoController productoController = new ProductoController();


        public ListarProducto()
        {
            InitializeComponent();
            CargarProductos();
        }

        private void CargarProductos()
        {
            productoDataGridView.Columns.Clear(); // Limpiar columnas anteriores

            List<Producto> producto = productoController.ObtenerTodosLosProductos();

            // Asignar a las columnas con el mismo ancho que el texto
            productoDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Asignar la lista al DataSource
            productoDataGridView.DataSource = new BindingList<Producto>(producto); // Para que se pueda editar si querés

            // Agregar botón "Eliminar"
            DataGridViewButtonColumn eliminarBtn = new DataGridViewButtonColumn();
            eliminarBtn.HeaderText = "Eliminar";
            eliminarBtn.Text = "Eliminar";
            eliminarBtn.Name = "Eliminar";
            eliminarBtn.UseColumnTextForButtonValue = true;
            productoDataGridView.Columns.Add(eliminarBtn);

            // Agregar botón "Modificar"
            DataGridViewButtonColumn modificarBtn = new DataGridViewButtonColumn();
            modificarBtn.HeaderText = "Modificar";
            modificarBtn.Text = "Modificar";
            modificarBtn.Name = "Modificar";
            modificarBtn.UseColumnTextForButtonValue = true;
            productoDataGridView.Columns.Add(modificarBtn);


            // Manejar clicks en los botones
            productoDataGridView.CellClick -= productoDataGridView_CellClick; // evitar múltiples suscripciones
            productoDataGridView.CellClick += productoDataGridView_CellClick;

            productoDataGridView.RowHeadersVisible = false;


        }

        private void productoDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            // Obtener la persona seleccionada
            Producto productoSeleccionado = (Producto)productoDataGridView.Rows[e.RowIndex].DataBoundItem;

            if (productoDataGridView.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                if (MessageBox.Show("¿Estás seguro que querés eliminar a esta persona?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (productoController.EliminarProducto(productoSeleccionado.idproducto))
                    {
                        MessageBox.Show("Producto eliminado correctamente.");
                        CargarProductos();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar.");
                    }
                }
            }
            else if (productoDataGridView.Columns[e.ColumnIndex].Name == "Modificar")
            {
                // Acá luego hacés el formulario para modificar
                Form1 form = (Form1)this.FindForm();
                form.MostrarFormularioAgregarModificar(productoSeleccionado);
            }
        }




        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            Form1 form = (Form1)this.FindForm();
            form.MostrarFormularioAgregarModificar();
        }

        private void btnAbrirVenta_Click(object sender, EventArgs e)
        {
            Form1 form= (Form1)this.FindForm();
            form.MostrarFormularioVentasProducto();
        }

        private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnAbrirPedidos_click(object sender, EventArgs e)
        {
            Form1 form = (Form1)this.FindForm();
            form.MostrarFormularioDetalleVentasProductos();
        }
    }
}
