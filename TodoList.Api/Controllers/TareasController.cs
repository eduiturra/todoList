using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.Api.Models;
using TodoList.BLL.Services;
using TodoList.BLL.Services.DTOs;

namespace TodoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TareasController : ControllerBase
    {
        private readonly ITareasService _tareasService;
        private readonly IMapper _mapper;

        public TareasController(ITareasService tareasService, IMapper mapper)
        {
            _tareasService = tareasService;
            _mapper = mapper;
        }
        [HttpGet("")]

        public IActionResult Get()
        {
            return Ok(_tareasService.GetTareas().ToList());
        }
        [HttpPost("")]
        public IActionResult PostAgregarTarea(TareasModel model)
        {
            var dto = _mapper.Map<TareasDTO>(model);
            _tareasService.AgregarTarea(dto);
            return Ok();
        }
        [HttpPut("TareaResuelta")]
        public IActionResult PutTareaResuelta(int idTarea)
        {
            _tareasService.UpdateTareaResuelta(idTarea);
            return Ok();
        }
    }
}