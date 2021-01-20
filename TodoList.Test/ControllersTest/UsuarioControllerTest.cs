using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using TodoList.Api.Controllers;
using TodoList.Api.Helpers;
using TodoList.Api.Models;
using TodoList.BLL.DTOs;
using TodoList.BLL.Services;
using TodoList.DAL.Models;

namespace TodoList.Test.ControllersTest
{
    [TestFixture]
    public class UsuarioControllerTest
    {
        private UsuariosController _controller;
        private Mock<IUsuariosService> _usuarioService;
        private Mock<IMapper> _mapper;

        [SetUp]
        public void Setup()
        {
            IOptions<AppSettings> appSetting = Options.Create<AppSettings>(new AppSettings() { Secret = ""});
            _usuarioService = new Mock<IUsuariosService>();
            _mapper = new Mock<IMapper>();
            _controller = new UsuariosController(appSetting, _usuarioService.Object, _mapper.Object);
        }
        [TestCase("", "", "", 3)]
        [TestCase("Edu", "pass", "Eduardo", 1)]
        [TestCase("Edu","Pass1","Eduardo",0)]
        public void PostAgregarUsuario_ModelStateValid_Test(string Username, string Pass, string Name, int errors)
        {
            var model = new UsuariosModel()
            {
                Username = Username,
                Password = Pass,
                Nombre = Name
            };
            var result = ValidateModel(model);
            Assert.AreEqual(errors, result.Count);
        }


        [Test]
        public void PostInscribirUsuarioCall_Service_AutoMapper_Test()
        {
            _controller.PostInscribirUsuario(It.IsAny<UsuariosModel>());

            _usuarioService.Verify(a => a.AgregarUsuario(It.IsAny<UsuariosDTO>()), Times.Once);
            _mapper.Verify(a => a.Map<UsuariosDTO>(It.IsAny<UsuariosDTO>()), Times.Once);

        }

        [TestCase("", "", 2)]
        [TestCase("Edu", "Pass1", 0)]
        public void Post_Login_ModelStateValid_Test(string Username, string Pass, int errors)
        {
            var model = new LoginModel()
            {
                Username = Username,
                Password = Pass,
            };
            var result = ValidateModel(model);
            Assert.AreEqual(errors, result.Count);
        }

        [Test]
        public async Task PostLogin_Call_Service_AutoMapper_Test()
        {
            await _controller.Login(new LoginModel());

            _usuarioService.Verify(a => a.Login(It.IsAny<LoginDTO>(), It.IsAny<string>()), Times.Once);
            _mapper.Verify(a => a.Map<LoginDTO>(It.IsAny<LoginModel>()), Times.Once);

        }

        [TestCase("token")]
        [TestCase(null)]
        public async Task Post_Login_Return_Test(string token)
        {
            List<Usuarios> usuario = new List<Usuarios>();
            _usuarioService.Setup(a => a.Login(It.IsAny<LoginDTO>(), It.IsAny<string>())).Returns(async () =>
            {
                return token;
            });

            var result = await _controller.Login(new LoginModel()) as ObjectResult;

            if (token == null)
            {
                Assert.AreEqual(400, result.StatusCode);

            }
            else
            {
                Assert.AreEqual(200, result.StatusCode);

            }
        }

        //[Test]
        //public void Get_Call_Service_GetUsuarios_Test()
        //{
        //    _controller.Get();

        //    _usuarioService.Verify(a => a.GetUsuarios(), Times.Once);
        //}

        //[Test]
        //public void Get_Service_GetUsuarios_Return_Test()
        //{
        //    List<Usuarios> usuario = new List<Usuarios>();
        //    _usuarioService.Setup(a => a.GetUsuarios()).Returns(usuario);

        //    var result = _controller.Get() as OkObjectResult;

        //    Assert.AreEqual(usuario, result.Value);
        //}


        private List<ValidationResult> ValidateModel<T>(T model)
        {
            var context = new System.ComponentModel.DataAnnotations.ValidationContext(model, null, null);
            var result = new List<ValidationResult>();
            Validator.TryValidateObject(model, context, result, true);

            return result;
        }
    }
}
