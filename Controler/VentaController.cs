using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Model;


namespace Controler
{
    public class VentaController
    {
        public bool RegistrarVenta(Venta venta)
        {
            try
            {
                // Insertar la venta principal
                string insertVentaQuery = "INSERT INTO ventas (fechaventa, totalventa) VALUES (@fecha, @total); SELECT SCOPE_IDENTITY();";

                SqlParameter[] parametrosVenta = new SqlParameter[]
                {
                new SqlParameter("@fecha", venta.FechaVenta),
                new SqlParameter("@total", venta.TotalVenta)
                };

                object result = Database.ExecuteScalar(insertVentaQuery, parametrosVenta);
                int idVenta = Convert.ToInt32(result);

                // Insertar los detalles y actualizar stock
                foreach (var detalle in venta.Detalles)
                {
                    // Validar stock actual
                    string consultaStock = "SELECT stock FROM productos WHERE idproducto = @idproducto";
                    SqlParameter[] parametrosConsultaStock = new SqlParameter[]
                    {
                new SqlParameter("@idproducto", detalle.IdProducto)
                    };

                    DataTable stockResult = Database.Select(consultaStock, parametrosConsultaStock);
                    if (stockResult.Rows.Count == 0)
                    {
                        Console.WriteLine($"El producto con ID {detalle.IdProducto} no existe.");
                        return false;
                    }

                    int stockActual = Convert.ToInt32(stockResult.Rows[0]["stock"]);
                    if (detalle.Cantidad > stockActual)
                    {
                        Console.WriteLine($"Stock insuficiente para el producto: {detalle.Producto.nombreproducto}");
                        return false;
                    }

                    // Insertar el detalle de la venta
                    string insertDetalleQuery = @"INSERT INTO detalleventas (idventa, idproducto, cantidad, preciounitario)
                                           VALUES (@idventa, @idproducto, @cantidad, @precio)";
                    SqlParameter[] parametrosDetalle = new SqlParameter[]
                    {
                     new SqlParameter("@idventa", idVenta),
                    new SqlParameter("@idproducto", detalle.IdProducto),
                new SqlParameter("@cantidad", detalle.Cantidad),
                new SqlParameter("@precio", detalle.PrecioUnitario)
                    };

                    Database.ExecuteNonQuery(insertDetalleQuery, parametrosDetalle);

                    // Actualizar stock
                    string actualizarStockQuery = "UPDATE productos SET stock = stock - @cantidad WHERE idproducto = @idproducto";
                    Database.ExecuteNonQuery(actualizarStockQuery, parametrosDetalle);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al registrar venta: " + ex.Message);
                return false;
            }
        }
        public List<Venta> ObtenerTodasLasVentas()
        {
            var ventas = new List<Venta>();
            try
            {
                string query = "SELECT * FROM ventas";
                DataTable tabla = Database.Select(query);

                foreach (DataRow row in tabla.Rows)
                {
                    ventas.Add(new Venta
                    {
                        IDVenta = Convert.ToInt32(row["idventa"]),
                        FechaVenta = Convert.ToDateTime(row["fechaventa"]),
                        TotalVenta = Convert.ToDecimal(row["totalventa"])
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener ventas: " + ex.Message);
            }

            return ventas;
        }
    }
}