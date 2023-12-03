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
    public class MantenimientoController : ControllerBase
    {
        public IMantenimientoService _mantenimientoService;

        private Mantenimiento Convertir(MantenimientoModel mantenimiento)
        {
            return new Mantenimiento
            {
                Id = mantenimiento.Id,
                TipoMantenimiento = mantenimiento.TipoMantenimiento,
                FechaInicio = mantenimiento.FechaFinalizacion,
                FechaFinalizacion = mantenimiento.FechaFinalizacion,
                Costo = mantenimiento.Costo,
                DescripcionMantenimiento = mantenimiento.DescripcionMantenimiento,
                Estado = mantenimiento.Estado,
                FechaActualizado = mantenimiento.FechaActualizado,
                IdAutomovil = mantenimiento.IdAutomovil
            };
        }
        private MantenimientoModel Convertir(Mantenimiento mantenimiento)
        {
            return new MantenimientoModel
            {
                Id = mantenimiento.Id,
                TipoMantenimiento = mantenimiento.TipoMantenimiento,
                FechaInicio = mantenimiento.FechaFinalizacion,
                FechaFinalizacion = mantenimiento.FechaFinalizacion,
                Costo = mantenimiento.Costo,
                DescripcionMantenimiento = mantenimiento.DescripcionMantenimiento,
                Estado = mantenimiento.Estado,
                FechaActualizado = mantenimiento.FechaActualizado,
                IdAutomovil = mantenimiento.IdAutomovil
            };
        }
        public MantenimientoController(IMantenimientoService mantenimientoService)
        {
            _mantenimientoService = mantenimientoService;
            
        }

        // GET: api/<MantenimientoController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Mantenimiento> lista = _mantenimientoService.GetMantenimientosAsync().Result;
            List<MantenimientoModel> mantenimientos = new List<MantenimientoModel>();

            foreach (var item in lista)
            {
                mantenimientos.Add(Convertir(item));

            }

            return Ok(mantenimientos);
        }

        // GET api/<MantenimientoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Mantenimiento mantenimiento = _mantenimientoService.GetById(id);
            MantenimientoModel mantenimientoModel = Convertir(mantenimiento);

            return Ok(mantenimientoModel);
        }

        // POST api/<MantenimientoController>
        [HttpPost]
        public IActionResult Post([FromBody] MantenimientoModel mantenimiento)
        {
            Mantenimiento entity = Convertir(mantenimiento);
            _mantenimientoService.AddMantenimiento(entity);
            return Ok(Convertir(mantenimiento));
        }

        // PUT api/<MantenimientoController>/5
        [HttpPut]
        public IActionResult Put([FromBody] MantenimientoModel mantenimiento)
        {
            Mantenimiento entity = Convertir(mantenimiento);
            _mantenimientoService.UpdateMantenimiento(entity);
            return Ok(Convertir(entity));
        }

        // DELETE api/<MantenimientoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Mantenimiento mantenimiento = new Mantenimiento
            {
                Id = id
            };
            _mantenimientoService.DeleteMantenimiento(mantenimiento);
            return Ok();
        }
    }
}
