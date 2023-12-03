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
    public class SeguroController : ControllerBase
    {
        public ISeguroService _seguroService;

        private Seguro Convertir(SeguroModel seguro)
        {
            return new Seguro
            {
                Id = seguro.Id,
                TipoSeguro = seguro.TipoSeguro,
                CostoSeguro = seguro.CostoSeguro,
                Descripcion = seguro.Descripcion
            };
        }
        private SeguroModel Convertir(Seguro seguro)
        {
            return new SeguroModel
            {
                Id = seguro.Id,
                TipoSeguro = seguro.TipoSeguro,
                CostoSeguro = seguro.CostoSeguro,
                Descripcion = seguro.Descripcion
            };
        }

        public SeguroController(ISeguroService seguroService)
        {
            _seguroService = seguroService;
        }

        // GET: api/<SeguroController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Seguro> lista = _seguroService.GetSegurosAsync().Result;
            List<SeguroModel> seguros = new List<SeguroModel>();

            foreach (var item in lista)
            {
                seguros.Add(Convertir(item));

            }

            return Ok(seguros);
        }

        // GET api/<SeguroController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Seguro seguro = _seguroService.GetById(id);
            SeguroModel seguroModel = Convertir(seguro);

            return Ok(seguroModel);
        }

        // POST api/<SeguroController>
        [HttpPost]
        public IActionResult Post([FromBody] SeguroModel seguro)
        {
            Seguro entity = Convertir(seguro);
            _seguroService.AddSeguro(entity);
            return Ok(Convertir(seguro));
        }

        // PUT api/<SeguroController>/5
        [HttpPut]
        public IActionResult Put([FromBody] SeguroModel seguro)
        {
            Seguro entity = Convertir(seguro);
            _seguroService.UpdateSeguro(entity);
            return Ok(Convertir(entity));
        }

        // DELETE api/<SeguroController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Seguro seguro = new Seguro
            {
                Id = id
            };
            _seguroService.DeleteSeguro(seguro);
            return Ok();
        }
    }
}
