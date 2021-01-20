using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TodoList.BLL.DTOs;
using TodoList.DAL.Models;
using TodoList.DAL.Repositories;
using TodoList.DAL.UnitOfWork;

namespace TodoList.BLL.Services
{
    public class UsuariosService : IUsuariosService
    {
        private readonly IUnitOfWork _unit;
        public UsuariosService(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public async Task<string> Login(LoginDTO model, string secret)
        {
            var user = await _unit.UsuarioRepo.FindBySingleAsync(x => x.Username == model.Username);

            // return null if user not found
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.Password)) return null;

            // authentication successful so generate jwt token
            var token = GenerateJwtToken(user, secret);

            return token;
        }

        public void AgregarUsuario(UsuariosDTO dto)
        {
            _unit.UsuarioRepo.Add(
                new Usuarios()
                {
                    Nombre = dto.Nombre,
                    Username = dto.Username,
                    Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
                }
            );
            _unit.Complete();
        }

        public IEnumerable<Usuarios> GetUsuarios()
        {
            return _unit.UsuarioRepo.GetAll();
        }


        private string GenerateJwtToken(Usuarios user, string secret)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("Username", user.Username.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
