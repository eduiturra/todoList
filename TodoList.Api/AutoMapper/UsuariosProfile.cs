using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Api.Models;
using TodoList.BLL.DTOs;
using TodoList.DAL.Models;

namespace TodoList.Api.AutoMapper
{
    public class UsuariosProfile : Profile
    {
        public UsuariosProfile()
        {
            CreateMap<LoginModel, LoginDTO>();
            CreateMap<UsuariosModel, UsuariosDTO>();
        }
    }
}