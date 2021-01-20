using System.Collections.Generic;
using TodoList.BLL.Services.DTOs;
using TodoList.DAL.Models;

namespace TodoList.BLL.Services
{
    public interface ITareasService
    {
        IEnumerable<Tareas> GetTareas();
        void AgregarTarea(TareasDTO tareasDTO);
        void UpdateTareaResuelta(int idTarea);

    }
}