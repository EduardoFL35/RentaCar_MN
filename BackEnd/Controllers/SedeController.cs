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
    public class SedeController : ControllerBase
    {
        public ISedeService _sedeService;

        private Sede Convertir(SedeModel sede)
        {
            return new Sede
            {
                Id = sede.Id,
                NombreUbi = sede.NombreUbi,
                Provincia = sede.Provincia,
                Ciudad = sede.Ciudad,
                DireccionSede = sede.DireccionSede
            };
        }
        private SedeModel Convertir(Sede sede)
        {
            return new SedeModel
            {
                Id = sede.Id,
                NombreUbi = sede.NombreUbi,
                Provincia = sede.Provincia,
                Ciudad = sede.Ciudad,
                DireccionSede = sede.DireccionSede
            };
        }

        public SedeController(ISedeService sedeService)
        {
            _sedeService = sedeService;
        }


        // GET: api/<SedeController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Sede> lista = _sedeService.GetSedesAsync().Result;
            List<SedeModel> sedes = new List<SedeModel>();

            foreach (var item in lista)
            {
                sedes.Add(Convertir(item));

            }

            return Ok(sedes);
        }

        // GET api/<SedeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Sede sede = _sedeService.GetById(id);
            SedeModel sedeModel = Convertir(sede);

            return Ok(sedeModel);
        }

        // POST api/<SedeController>
        [HttpPost]
        public IActionResult Post([FromBody] SedeModel sede)
        {
            Sede entity = Convertir(sede);
            _sedeService.AddSede(entity);
            return Ok(Convertir(sede));
        }

        // PUT api/<SedeController>/5
        [HttpPut]
        public IActionResult Put([FromBody] SedeModel sede)
        {
            Sede entity = Convertir(sede);
            _sedeService.UpdateSede(entity);
            return Ok(Convertir(entity));
        }

        // DELETE api/<SedeController>/5
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Sede sede = new Sede
            {
                Id = id
            };
            _sedeService.DeleteSede(sede);
            return Ok();
        }
    }
}
