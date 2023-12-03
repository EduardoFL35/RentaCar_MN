using BackEnd.Models;
using BackEnd.Services.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionController : ControllerBase
    {
        public ITransaccionService _transaccionService;

        private Transaccione Convertir(TransaccionModel transaccion)
        {
            return new Transaccione
            {
                Id = transaccion.Id,
                FechaInicio = transaccion.FechaInicio,
                FechaDevolucion = transaccion.FechaDevolucion,
                CostoTotal = transaccion.CostoTotal,
                Detalles = transaccion.Detalles,
                ShipmentDate = transaccion.ShipmentDate,
                IdAutomovil = transaccion.IdAutomovil,
                IdCliente = transaccion.IdCliente,
                IdEmpleado = transaccion.IdEmpleado
            };
        }
        private TransaccionModel Convertir(Transaccione transaccion)
        {
            return new TransaccionModel
            {
                Id = transaccion.Id,
                FechaInicio = transaccion.FechaInicio,
                FechaDevolucion = transaccion.FechaDevolucion,
                CostoTotal = transaccion.CostoTotal,
                Detalles = transaccion.Detalles,
                ShipmentDate = transaccion.ShipmentDate,
                IdAutomovil = transaccion.IdAutomovil,
                IdCliente = transaccion.IdCliente,
                IdEmpleado = transaccion.IdEmpleado
            };
        }

        public TransaccionController(ITransaccionService transaccionService)
        {
            _transaccionService = transaccionService;
        }

        // GET: api/<TransaccionController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Transaccione> lista = _transaccionService.GetTransaccionesAsync().Result;
            List<TransaccionModel> transacciones = new List<TransaccionModel>();

            foreach (var item in lista)
            {
                transacciones.Add(Convertir(item));

            }

            return Ok(transacciones);
        }

        // GET api/<TransaccionController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Transaccione transaccion = _transaccionService.GetById(id);
            TransaccionModel transaccionModel = Convertir(transaccion);

            return Ok(transaccionModel);
        }

        // POST api/<TransaccionController>
        [HttpPost]
        public IActionResult Post([FromBody] TransaccionModel transaccion)
        {
            Transaccione entity = Convertir(transaccion);
            _transaccionService.AddTransaccion(entity);
            return Ok(Convertir(transaccion));
        }

        // PUT api/<TransaccionController>/5
        [HttpPut]
        public IActionResult Put([FromBody] TransaccionModel transaccion)
        {
            Transaccione entity = Convertir(transaccion);
            _transaccionService.UpdateTransaccion(entity);
            return Ok(Convertir(entity));
        }

        // DELETE api/<TransaccionController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Transaccione transaccion = new Transaccione
            {
                Id = id
            };
            _transaccionService.DeleteTransaccion(transaccion);
            return Ok();
        }
    }
}
