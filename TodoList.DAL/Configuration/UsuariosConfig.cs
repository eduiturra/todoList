using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.DAL.Models;

namespace TodoList.DAL.Configuration
{
    public class UsuariosConfig
    {
        public UsuariosConfig(EntityTypeBuilder<Usuarios> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Username);
            entityBuilder.HasMany(a => a.Tareas).WithOne(x => x.Usuarios).HasForeignKey(a => a.Username);


        }
    }
}
