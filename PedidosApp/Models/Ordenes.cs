using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosApp.Models
{
    public class Ordenes
    {
        [Key]
        [Required(ErrorMessage = "El campo ID no puede estar vacío")]
        [Range(0, 999999, ErrorMessage = "El campo Id no puede ser menor que cero o mayor a 999999")]
        public int OrdenId { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El campo ID no puede estar vacío")]
        [Range(0, 999999, ErrorMessage = "El campo Id no puede ser menor que cero o mayor a 999999")]
        public int SuplidorId { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío")]
        [Range(0, 999999, ErrorMessage = "El campo no puede ser menor que cero o mayor a 999999")]
        public decimal Monto { get; set; }

        [ForeignKey("OrdenId")]
        public virtual List<OrdenDetalle> ordenDetalles { get; set; } = new List<OrdenDetalle>();

        public Ordenes()
        {
            OrdenId = 0;
            Fecha = DateTime.Now;
            SuplidorId = 0;
            Monto = 0;
        }
    }

    public class OrdenDetalle
    {
        [Key]
        [Required(ErrorMessage = "El campo ID no puede estar vacío")]
        [Range(0, 999999, ErrorMessage = "El campo Id no puede ser menor que cero o mayor a 999999")]
        public int DetalleId { get; set; }

        [Required(ErrorMessage = "El campo ID no puede estar vacío")]
        [Range(0, 999999, ErrorMessage = "El campo MoraId no puede ser menor que cero o mayor a 999999")]
        public int OrdenId { get; set; }

        [Required(ErrorMessage = "El campo ID no puede estar vacío")]
        [Range(0, 999999, ErrorMessage = "El campo Id no puede ser menor que cero o mayor a 999999")]
        public int ProductoId { get; set; }
        [ForeignKey("ProductoId")]
        public Productos productos { get; set; }


        [Required(ErrorMessage = "El campo no puede estar vacío")]
        [Range(0, 999999, ErrorMessage = "El campo no puede ser menor que cero o mayor a 999999")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío")]
        public Decimal Costo { get; set; }

        public OrdenDetalle()
        {
            DetalleId = 0;
            OrdenId = 0;
            ProductoId = 0;
            this.productos = productos;
            Cantidad = 0;
            Costo = 0;
        }

        public OrdenDetalle(int detalleId, int ordenId, int productoId, int cantidad, decimal costo)
        {
            DetalleId = detalleId;
            OrdenId = ordenId;
            ProductoId = productoId;
            Cantidad = cantidad;
            Costo = costo;
        }

    }
}
