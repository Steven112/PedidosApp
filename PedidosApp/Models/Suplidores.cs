using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosApp.Models
{
    public class Suplidores
    {
        [Key]
        [Required(ErrorMessage = "El campo ID no puede estar vacío")]
        [Range(0, 999999, ErrorMessage = "El campo Id no puede ser menor que cero o mayor a 999999")]
        public int SuplidorId { get; set; }

        [Required(ErrorMessage = "El campo no puede estar vacío")]
        [MinLength(3, ErrorMessage = "El nombre es muy corto")]
        [MaxLength(40, ErrorMessage = "El nombre es muy largo")]
        public string Nombre { get; set; }

        
    }
}
