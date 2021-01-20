using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.DAL.Repositories;

namespace TodoList.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext _context { get; set; }
        public IUsuarioRepo UsuarioRepo { get; }
        public ITareasRepo TareasRepo { get; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            UsuarioRepo = new UsuarioRepo(context);
            TareasRepo = new TareasRepo(context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public Task CompleteSync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
