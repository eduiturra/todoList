using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.BLL.DTOs;
using TodoList.DAL.Models;

namespace TodoList.BLL.Services
{
    public interface IUsuariosService
    {
        void AgregarUsuario(UsuariosDTO dto);
        IEnumerable<Usuarios> GetUsuarios();
        Task<string> Login(LoginDTO model, string secret);
    }
}