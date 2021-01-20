using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.BLL.Services.DTOs;
using TodoList.DAL.Models;
using TodoList.DAL.UnitOfWork;

namespace TodoList.BLL.Services
{
    public class TareasService : ITareasService
    {
        private readonly IUnitOfWork _unit;
        public TareasService(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public void AgregarTarea(TareasDTO tareasDTO)
        {
            if (tareasDTO.Estado != "No Resuelto" || tareasDTO.Estado != "Resuelto")
            {
                throw new ArgumentException("Campo Estado tiene que ser Resuelto / No Resuelto", nameof(tareasDTO.Estado));
            }
            _unit.TareasRepo.Add(new Tareas()
            {
                Nombre = tareasDTO.Nombre,
                Username = tareasDTO.Username,
                Descripcion = tareasDTO.Descripcion,
                Estado = tareasDTO.Estado
            });
            _unit.Complete();

        }

        public IEnumerable<Tareas> GetTareas()
        {
            return _unit.TareasRepo.GetAll();
        }

        public void UpdateTareaResuelta(int idTarea)
        {
            var tarea = _unit.TareasRepo.Get(idTarea);
            if (tarea == null)
            {
                throw new ArgumentException("La Tarea no se ha encontrado", nameof(idTarea));

            }
            if (tarea.Estado == "Resuelto")
            {
                throw new ArgumentException("La Tarea ya está resuelta", nameof(idTarea));

            }
            tarea.Estado = "Resuelto";
            _unit.TareasRepo.Update(tarea);
            _unit.Complete();
        }
    }
}
