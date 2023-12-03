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
    public class ClienteController : ControllerBase
    {
        public IClienteService _clienteService;

        private Cliente Convertir(ClienteModel cliente)
        {
            return new Cliente
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Correo = cliente.Correo,
                Usuario = cliente.Usuario,
                Contraseña = cliente.Contraseña,
                DireccionUsuario = cliente.DireccionUsuario
            };
        }

        private ClienteModel Convertir(Cliente cliente)
        {
            return new ClienteModel
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Correo = cliente.Correo,
                Usuario = cliente.Usuario,
                Contraseña = cliente.Contraseña,
                DireccionUsuario = cliente.DireccionUsuario
            };
        }

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // GET: api/<ClienteController>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Cliente> lista = _clienteService.GetClientesAsync().Result;
            List<ClienteModel> clientes = new List<ClienteModel>();

            foreach (var item in lista)
            {
                clientes.Add(Convertir(item));

            }

            return Ok(clientes);
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Cliente cliente = _clienteService.GetById(id);
            ClienteModel clienteModel = Convertir(cliente);

            return Ok(clienteModel);
        }

        // POST api/<ClienteController>
        [HttpPost]
        public IActionResult Post([FromBody] ClienteModel cliente)
        {
            Cliente entity = Convertir(cliente);
            _clienteService.AddCliente(entity);
            return Ok(Convertir(cliente));
        }

        // PUT api/<ClienteController>/5
        [HttpPut]
        public IActionResult Put([FromBody] ClienteModel cliente)
        {
            Cliente entity = Convertir(cliente);
            _clienteService.UpdateCliente(entity);
            return Ok(Convertir(entity));
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Cliente cliente = new Cliente
            {
                Id = id
            };
            _clienteService.DeleteCliente(cliente);
            return Ok();
        }
    }
}
