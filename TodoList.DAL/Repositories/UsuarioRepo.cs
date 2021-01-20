using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.DAL.Models;

namespace TodoList.DAL.Repositories
{
    public class UsuarioRepo : RepositoryGeneric<Usuarios>, IUsuarioRepo
    {
        public UsuarioRepo(ApplicationDbContext db)
           : base(db)
        {

        }
    }
}
