using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TodoList.Api.Helpers;
using TodoList.Api.Models;
using TodoList.BLL.DTOs;
using TodoList.BLL.Services;
using TodoList.DAL.Models;
namespace TodoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly IUsuariosService _usuariosService;
        private readonly IMapper _mapper;
        public UsuariosController(
            IOptions<AppSettings> appSettings,
            IUsuariosService usuariosService,
            IMapper mapper
            )
        {
            _appSettings = appSettings.Value;
            _usuariosService = usuariosService;
            _mapper = mapper;
        }

        //[HttpGet]
        //[Authorize]
        //public IActionResult Get()
        //{
        //    return Ok(_usuariosService.GetUsuarios().ToList());
        //}

        [HttpPost("")]
        [Authorize]
        public IActionResult PostInscribirUsuario(UsuariosModel model)
        {
            var data = _mapper.Map<UsuariosDTO>(model);
            _usuariosService.AgregarUsuario(data);
            return Ok();
        }


        // POST: api/Usuarios
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {       
            var dto =  _mapper.Map<LoginDTO>(model);
            var token = await _usuariosService.Login(dto, _appSettings.Secret);

            if (token == null)
                return BadRequest(new { message = "Error Login" });

            return Ok(new TokenModel() { Token = token});
        }



    }
}
