using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.DAL.Models;

namespace TodoList.DAL.Repositories
{
    public class TareasRepo : RepositoryGeneric<Tareas>, ITareasRepo
    {
        public TareasRepo(ApplicationDbContext db)
           : base(db)
        {

        }
    }
}
