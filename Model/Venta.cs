using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Venta
    {
        public int IDVenta { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal TotalVenta { get; set; }

        // Lista de productos en esta venta
        public List<DetalleVenta> Detalles { get; set; }

        public Venta()
        {
            Detalles = new List<DetalleVenta>();
        }
    }
}
