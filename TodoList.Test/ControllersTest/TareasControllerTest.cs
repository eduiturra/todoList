using AutoMapper;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TodoList.Api.Controllers;
using TodoList.Api.Models;
using TodoList.BLL.Services;
using TodoList.BLL.Services.DTOs;

namespace TodoList.Test.ControllersTest
{
    [TestFixture]
    public class TareasControllerTest
    {
        private TareasController _controller;
        private Mock<ITareasService> _service;
        private Mock<IMapper> _mapper;

        [SetUp]
        public void Setup()
        {
            _service = new Mock<ITareasService>();
            _mapper = new Mock<IMapper>();
            _controller = new TareasController(_service.Object, _mapper.Object);
        }

        [TestCase("", "", "", 3)]
        [TestCase("Nombre", "Estado", "Descipcion", 0)]
        public void PostAgregarTarea_ModelStateValid_Test(string Nombre, string Estado, string Descripcion, int errors)
        {
            var model = new TareasModel()
            {
                Descripcion = Descripcion,
                Estado = Estado,
                Nombre = Nombre
            };
            var result = ValidateModel(model);
            Assert.AreEqual(errors, result.Count);
        }
        [Test]
        public void PostAgregar_Tarea_Call_Service_AutoMapper_Test()
        {
            _controller.PostAgregarTarea(It.IsAny<TareasModel>());

            _service.Verify(a => a.AgregarTarea(It.IsAny<TareasDTO>()), Times.Once);
            _mapper.Verify(a => a.Map<TareasDTO>(It.IsAny<TareasModel>()), Times.Once);

        }


        private List<ValidationResult> ValidateModel<T>(T model)
        {
            var context = new System.ComponentModel.DataAnnotations.ValidationContext(model, null, null);
            var result = new List<ValidationResult>();
            Validator.TryValidateObject(model, context, result, true);

            return result;
        }
    }
}
