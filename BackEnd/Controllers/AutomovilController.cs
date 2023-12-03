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
    public class AutomovilController : ControllerBase
    {
        public IAutomovilService _automovilService;

        private Automovile Convertir(AutomovilModel automovil)
        {
            return new Automovile
            {
                Id = automovil.Id,
                Marca = automovil.Marca,
                Modelo = automovil.Modelo,
                Anio = automovil.Anio,
                Placa = automovil.Placa,
                Disponibilidad = automovil.Disponibilidad,
                Precio = automovil.Precio,
                FechaActualizado = automovil.FechaActualizado,
                IdCategorias = automovil.IdCategorias,
                IdDeSedes = automovil.IdDeSedes,
                IdSeguros = automovil.IdSeguros
            };
        }
        private AutomovilModel Convertir(Automovile automovil)
        {
            return new AutomovilModel
            {
                Id = automovil.Id,
                Marca = automovil.Marca,
                Modelo = automovil.Modelo,
                Anio = automovil.Anio,
                Placa = automovil.Placa,
                Disponibilidad = automovil.Disponibilidad,
                Precio = automovil.Precio,
                FechaActualizado = automovil.FechaActualizado,
                IdCategorias = automovil.IdCategorias,
                IdDeSedes = automovil.IdDeSedes,
                IdSeguros = automovil.IdSeguros
            };
        }

        public AutomovilController(IAutomovilService automovilService)
        {
            _automovilService = automovilService;
        }



        // GET: api/<AutomovilController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Automovile> lista = _automovilService.GetAutomovilesAsync().Result;
            List<AutomovilModel> automoviles = new List<AutomovilModel>();

            foreach (var item in lista)
            {
                automoviles.Add(Convertir(item));

            }

            return Ok(automoviles);
        }

        // GET api/<AutomovilController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Automovile automovil = _automovilService.GetById(id);
            AutomovilModel automovilModel = Convertir(automovil);

            return Ok(automovilModel);
        }

        // POST api/<AutomovilController>
        [HttpPost]
        public IActionResult Post([FromBody] AutomovilModel automovil)
        {
            Automovile entity = Convertir(automovil);
            _automovilService.AddAutomovil(entity);
            return Ok(Convertir(automovil));
        }

        // PUT api/<AutomovilController>/5
        [HttpPut]
        public IActionResult Put([FromBody] AutomovilModel automovil)
        {
            Automovile entity = Convertir(automovil);
            _automovilService.UpdateAutomovil(entity);
            return Ok(Convertir(entity));
        }

        // DELETE api/<AutomovilController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Automovile automovil = new Automovile
            {
                Id = id
            };
            _automovilService.DeleteAutomovil(automovil);
            return Ok();
        }
    }
}
