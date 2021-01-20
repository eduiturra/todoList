using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.DAL.Models;

namespace TodoList.DAL.Configuration
{
    public class TareasConfig
    {
        public TareasConfig(EntityTypeBuilder<Tareas> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
        }
    }
}
