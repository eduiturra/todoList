using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.DAL.Models
{
    public class Tareas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }
        public string Descripcion { get; set; }
        public string Username { get; set; }
        public Usuarios Usuarios { get; set; }
    }
}
