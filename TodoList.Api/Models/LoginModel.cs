using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Api.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "El Campo es obligatorio")]
        public string Username { get; set; }
        [Required(ErrorMessage = "El Campo es obligatorio")]
        public string Password { get; set; }
    }
}
