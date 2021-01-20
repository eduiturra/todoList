using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Api.Models
{
    public class UsuariosModel
    {
        [Required(ErrorMessage = "El campo es requerido")]
        public string Username { get; set; }
        [Required]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "La contraseña debe ser alfanumérica y contener una mayúscula y una minúscula")]
        public string Password { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public string Nombre { get; set; }
    }
}
