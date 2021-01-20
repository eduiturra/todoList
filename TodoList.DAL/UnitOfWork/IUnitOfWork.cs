using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.DAL.Repositories;

namespace TodoList.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUsuarioRepo UsuarioRepo { get; }
        ITareasRepo TareasRepo { get; }
        int Complete();
        Task CompleteSync();
    }
}
