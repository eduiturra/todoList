using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.DAL.Configuration;
using TodoList.DAL.Models;

namespace TodoList.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options
        )
            : base(options)
        {

        }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Tareas> Tareas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new UsuariosConfig(modelBuilder.Entity<Usuarios>());
            new TareasConfig(modelBuilder.Entity<Tareas>());
        }

    }
}