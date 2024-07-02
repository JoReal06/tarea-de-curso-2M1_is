using AutoMapper;
using Empresa_API_FINAL.Controllers;
using Empresa_API_FINAL.Repository.IRepository;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using SharedModels;
using SharedModels.Dto.EmpleadoDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaTests
{
    public class EmpleadoControllerTest
    {
        
        private readonly Mock<IEmpleadoRepository> _mockEmpleadoRepo;
        private readonly Mock<ILogger<EmpleadoController>> _mockLogger;
        private readonly Mock<IMapper> _mockMapper;
        private readonly EmpleadoController _controller;

        public EmpleadoControllerTest()
        {
            _mockEmpleadoRepo = new Mock<IEmpleadoRepository>();
            _mockLogger = new Mock<ILogger<EmpleadoController>>();
            _mockMapper = new Mock<IMapper>();
            _controller = new EmpleadoController(_mockEmpleadoRepo.Object,_mockLogger.Object,_mockMapper.Object);

        }

        [Fact]
        public async Task GetEmpleadosTest_retornarOk_conUnaListaDeEmpeados()
        {
            var empleados = new List<Empleado>
            {
                new Empleado{ EmpleadoId = 2, primerNombre = "messi"}
            };
            var EmpleadoDtos = new List<EmpleadoReadDto>
            {
                new EmpleadoReadDto{ EmpleadoId = 2,primerNombre = "messi" }
            };

            _mockEmpleadoRepo.Setup(repo => repo.GetAllAsync(null)).ReturnsAsync(empleados);
            _mockMapper
                .Setup(mapper =>
                mapper.Map<IEnumerable<EmpleadoReadDto>>(It.IsAny<IEnumerable<Empleado>>()))
                .Returns(EmpleadoDtos);


            var resultado = await _controller.GetEmpleados();

            var TodoOkey = Assert.IsType<OkObjectResult>(resultado.Result);
            var Valor = Assert.IsType<List<EmpleadoReadDto>>(TodoOkey.Value);
            Assert.Single(Valor);
            Assert.Equal("messi", Valor[0].primerNombre);
        }
        public async Task GetEmpleado_retornarOk_conEmpleadoEncontrado()
        {
           
            var empleado = new Empleado { EmpleadoId = 1, primerNombre = "jose mena" };
            var empleadoDto = new EmpleadoReadDto { EmpleadoId = 1, primerNombre = "jose mena" };

            _mockEmpleadoRepo.Setup(repo => repo.GetById(1)).ReturnsAsync(empleado);
            _mockMapper.Setup(mapper => mapper.Map<EmpleadoReadDto>(It.IsAny<Empleado>()))
                .Returns(empleadoDto);

            var resultado = await _controller.GetEmpleado(1);

            var okeyResultado = Assert.IsType<OkObjectResult>(resultado.Result);
            var valor = Assert.IsType<EmpleadoReadDto>(okeyResultado.Value);
            Assert.Equal("jose mena", valor.primerNombre);
        }

     
    }
}
