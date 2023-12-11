using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    [Authorize]
    public class ClienteController : Controller
    {

        IClienteHelper clienteHelper;
        public string Token { get; set; }


        public ClienteController(IClienteHelper _clienteHelper)
        {
            clienteHelper = _clienteHelper;

        }
        // GET: ClienteController
        public ActionResult Index()
        {
            Token = HttpContext.Session.GetString("token");
            clienteHelper.Token = Token;
            List<ClienteViewModel> clientes = clienteHelper.GetAll();

            return View(clientes);
        }

        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {

            Token = HttpContext.Session.GetString("token");
            clienteHelper.Token = Token;
            ClienteViewModel cliente = clienteHelper.GetById(id);

            return View(cliente);
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {

            Token = HttpContext.Session.GetString("token");
            clienteHelper.Token = Token;
            ClienteViewModel cliente = new ClienteViewModel();



            return View(cliente);
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel cliente)
        {
            try
            {
                Token = HttpContext.Session.GetString("token");
                clienteHelper.Token = Token;

                clienteHelper.AddCliente(cliente);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            Token = HttpContext.Session.GetString("token");
            clienteHelper.Token = Token;

            ClienteViewModel cliente = clienteHelper.GetById(id);

            return View(cliente);
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteViewModel cliente)
        {
            try
            {
                Token = HttpContext.Session.GetString("token");
                clienteHelper.Token = Token;

                clienteHelper.EditCliente(cliente);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            Token = HttpContext.Session.GetString("token");
            clienteHelper.Token = Token;

            ClienteViewModel cliente = clienteHelper.GetById(id);

            return View(cliente);
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ClienteViewModel cliente)
        {
            try
            {
                Token = HttpContext.Session.GetString("token");
                clienteHelper.Token = Token;

                clienteHelper.DeleteCliente(cliente.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}