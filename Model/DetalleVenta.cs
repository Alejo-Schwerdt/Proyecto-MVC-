using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class DetalleVenta
    {
        public int IDDetalleVenta { get; set; }
        public int IDVenta { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }

        // Propiedades de navegación
        public Producto Producto { get; set; }
    }
}
