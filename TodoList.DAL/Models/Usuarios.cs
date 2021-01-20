using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.DAL.Models
{
    public class Usuarios
    {
        public Usuarios()
        {
            Tareas = new HashSet<Tareas>();
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public ICollection<Tareas> Tareas { get; set; }
    }
}
