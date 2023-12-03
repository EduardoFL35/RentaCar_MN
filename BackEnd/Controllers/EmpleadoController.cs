using BackEnd.Models;
using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        public IEmpleadoService _empleadoService;

        private Empleado Convertir(EmpleadoModel empleado)
        {
            return new Empleado
            {
                Id = empleado.Id,
                Nombre = empleado.Nombre,
                Apellido = empleado.Apellido,
                FechaContratacion = empleado.FechaContratacion,
                IdSede = empleado.IdSede
            };
        }

        private EmpleadoModel Convertir(Empleado empleado)
        {
            return new EmpleadoModel
            {
                Id = empleado.Id,
                Nombre = empleado.Nombre,
                Apellido = empleado.Apellido,
                FechaContratacion = empleado.FechaContratacion,
                IdSede = empleado.IdSede
            };
        }

        public EmpleadoController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        // GET: api/<EmpleadoController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Empleado> lista = _empleadoService.GetEmpleadosAsync().Result;
            List<EmpleadoModel> empleados = new List<EmpleadoModel>();

            foreach (var item in lista)
            {
                empleados.Add(Convertir(item));

            }

            return Ok(empleados);
        }

        // GET api/<EmpleadoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Empleado empleado = _empleadoService.GetById(id);
            EmpleadoModel empleadoModel = Convertir(empleado);

            return Ok(empleadoModel);
        }

        // POST api/<EmpleadoController>
        [HttpPost]
        public IActionResult Post([FromBody] EmpleadoModel empleado)
        {
            Empleado entity = Convertir(empleado);
            _empleadoService.AddEmpleado(entity);
            return Ok(Convertir(empleado));
        }

        // PUT api/<EmpleadoController>/5
        [HttpPut]
        public IActionResult Put([FromBody] EmpleadoModel empleado)
        {
            Empleado entity = Convertir(empleado);
            _empleadoService.UpdateEmpleado(entity);
            return Ok(Convertir(entity));
        }

        // DELETE api/<EmpleadoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Empleado empleado = new Empleado
            {
                Id = id
            };
            _empleadoService.DeleteEmpleado(empleado);
            return Ok();
        }
    }
}
