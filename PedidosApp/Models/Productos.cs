using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosApp.Models
{
    public class Productos
    {
        [Key]
        [Required(ErrorMessage = "El campo ID no puede estar vacío")]
        [Range(0, 999999, ErrorMessage = "El campo Id no puede ser menor que cero o mayor a 999999")]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío")]
        [MinLength(3,ErrorMessage ="La descripcion es muy corta")]
        [MaxLength(40, ErrorMessage = "La descripcion es muy larga")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío")]
        [Range(0, 999999, ErrorMessage = "El campo no puede ser menor que cero o mayor a 999999")]
        public Decimal Costo { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío")]
        [Range(0, 999999, ErrorMessage = "El campo no puede ser menor que cero o mayor a 999999")]
        public int Inventario { get; set; }

    }
}
