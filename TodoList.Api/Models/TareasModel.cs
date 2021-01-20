using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Api.Models
{
    public class TareasModel
    {
        [Required(ErrorMessage = "El Campo es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Campo es obligatorio")]
        public string Estado { get; set; }
        [Required(ErrorMessage = "El Campo es obligatorio")]
        public string Descripcion { get; set; }
    }
}
