using System;
using System.Windows.Forms;
using Controler;
using Model;

namespace Prueba_MCV
{
    public partial class AgregarModificarProducto: UserControl
    {
        private ProductoController productoController;
        // Variables internas para almacenar el producto actual
        private Producto producto;

        // Evento que otros pueden suscribirse
        public event Action VolverAListar;

        public AgregarModificarProducto()
        {
            InitializeComponent();
            productoController = new ProductoController();
        }

        // Propiedad para establecer y obtener un producto completo
        public void Inicializar(Producto producto = null)
        {
            this.producto = producto;

            if (this.producto != null)
            {
                // Modo modificar
                nombreTextBox.Text = this.producto.nombreproducto;
                descripcionTextBox.Text = this.producto.descripcionproducto;
                tipoTextBox.Text = this.producto.tipoproducto;
                valorTextBox.Text = this.producto.valorproducto.ToString();
                stockTextBox.Text = this.producto.stockproducto.ToString();
                marcaTextBox.Text = this.producto.marcaproducto;
                btnAgregarModificar.Text = "Modificar";
            }
            else
            {
                // Modo agregar: limpiar campos
                nombreTextBox.Text = "";
                descripcionTextBox.Text = "";
                tipoTextBox.Text = "";
                valorTextBox.Text = "";
                stockTextBox.Text = "";
                marcaTextBox.Text = "";
                btnAgregarModificar.Text = "Agregar";
            }
        }


        private void agregarModificarButton_Click(object sender, EventArgs e)
        {
            if (producto == null) // Si Producto es null, estamos en modo agregar
            {
                AgregarProducto();
            }
            else // Si Producto no es null, estamos en modo modificar
            {
                ModificarProducto();
            }
        }

        // Método para agregar un producto
        private void AgregarProducto()
        {
            try
            {
                // Obtener los valores de los campos de texto
                string nombreproducto = nombreTextBox.Text;
                string descripcionproducto = descripcionTextBox.Text;
                string tipoproducto = tipoTextBox.Text;
                string marcaproducto = marcaTextBox.Text;

                // Convertir valores numéricos
                if (!int.TryParse(stockTextBox.Text, out int stockproducto))
                {
                    MessageBox.Show("Stock no es un número válido.");
                    return;
                }

                if (!int.TryParse(valorTextBox.Text, out int valorproducto))
                {
                    MessageBox.Show("Valor no es un número válido.");
                    return;
                }

                // Crear una nueva instancia del producto
                Producto nuevoProducto = new Producto(0, nombreproducto, descripcionproducto, tipoproducto, valorproducto, stockproducto, marcaproducto);
                nuevoProducto.marcaproducto = marcaproducto;

                // Guardar en la base de datos
                bool resultado = productoController.GuardarProducto(nuevoProducto);

                // Mostrar mensaje
                MessageBox.Show(resultado ? "Producto agregado exitosamente." : "Error al agregar el producto.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                VolverAListar?.Invoke(); // Notificar al formulario que debe recargar la lista
            }
        }

        // Método para modificar un producto
        private void ModificarProducto()
        {
            try
            {
                // Obtener los valores de los campos de texto
                string nombre = nombreTextBox.Text;
                string descripcion = descripcionTextBox.Text;
                string tipo = tipoTextBox.Text;

                // Modificar los datos del producto existente
                producto.nombreproducto = nombre;
                producto.descripcionproducto = descripcion;
                producto.tipoproducto = tipo;

                bool resultado = productoController.ModificarProducto(producto);

                // Mostrar mensaje de éxito o error
                MessageBox.Show(resultado ? "Producto modificado exitosamente." : "Error al modificar el producto.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                VolverAListar?.Invoke();
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            VolverAListar?.Invoke();
        }

        private void lblValor_Click(object sender, EventArgs e)
        {

        }

        private void nombreTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblDescripcion_Click(object sender, EventArgs e)
        {

        }
    }
}
