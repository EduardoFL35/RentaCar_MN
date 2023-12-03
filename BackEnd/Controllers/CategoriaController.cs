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
    public class CategoriaController : ControllerBase
    {
        public ICategoriaService _categoriaService;

        private Categoria Convertir(CategoriaModel categoria)
        {
            return new Categoria
            {
                Id = categoria.Id,
                DescripcionCategoria = categoria.DescripcionCategoria,
                Licencia = categoria.Licencia
            };
        }
        private CategoriaModel Convertir(Categoria categoria)
        {
            return new CategoriaModel
            {
                Id = categoria.Id,
                DescripcionCategoria = categoria.DescripcionCategoria,
                Licencia = categoria.Licencia
            };
        }

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        // GET: api/<CategoriaController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Categoria> lista = _categoriaService.GetCategoriasAsync().Result;
            List<CategoriaModel> categorias = new List<CategoriaModel>();

            foreach (var item in lista)
            {
                categorias.Add(Convertir(item));

            }

            return Ok(categorias);
        }

        // GET api/<CategoriaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Categoria categoria = _categoriaService.GetById(id);
            CategoriaModel categoriaModel = Convertir(categoria);

            return Ok(categoriaModel);
        }

        // POST api/<CategoriaController>
        [HttpPost]
        public IActionResult Post([FromBody] CategoriaModel categoria)
        {
            Categoria entity = Convertir(categoria);
            _categoriaService.AddCategoria(entity);
            return Ok(Convertir(categoria));
        }

        // PUT api/<CategoriaController>/5
        [HttpPut]
        public IActionResult Put([FromBody] CategoriaModel categoria)
        {
            Categoria entity = Convertir(categoria);
            _categoriaService.UpdateCategoria(entity);
            return Ok(Convertir(entity));
        }

        // DELETE api/<CategoriaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Categoria categoria = new Categoria
            {
                Id = id
            };
            _categoriaService.DeleteCategoria(categoria);
            return Ok();
        }
    }
}
