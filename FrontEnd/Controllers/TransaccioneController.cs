using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    [Authorize]
    public class TransaccioneController : Controller
    {

        ITransaccioneHelper transaccioneHelper;
        IAutomovileHelper automovileHelper;
        IClienteHelper clienteHelper;
        IEmpleadoHelper empleadoHelper;


        public string Token { get; set; }


        public TransaccioneController(ITransaccioneHelper _transaccioneHelper
                                        , IAutomovileHelper _automovileHelper
                                        , IClienteHelper _clienteHelper
                                        , IEmpleadoHelper _empleadoHelper
                                        )
        {
            transaccioneHelper = _transaccioneHelper;
            automovileHelper = _automovileHelper;
            clienteHelper = _clienteHelper;
            empleadoHelper = _empleadoHelper;
        }
            // GET: TransaccioneController
            public ActionResult Index()
        {
            Token = HttpContext.Session.GetString("token");
            transaccioneHelper.Token = Token;
            List<TransaccioneViewModel> transacciones = transaccioneHelper.GetAll();

            return View(transacciones);
        }

        // GET: TransaccioneController/Details/5
        public ActionResult Details(int id)
        {

            Token = HttpContext.Session.GetString("token");
            transaccioneHelper.Token = Token;
            TransaccioneViewModel transaccione = transaccioneHelper.GetById(id);

            return View(transaccione);
        }

        // GET: TransaccioneController/Create
        public ActionResult Create()
        {

            Token = HttpContext.Session.GetString("token");
            transaccioneHelper.Token = Token;

            TransaccioneViewModel transaccione = new TransaccioneViewModel();
            transaccione.Automoviles = automovileHelper.GetAll();
            transaccione.Clientes = clienteHelper.GetAll();
            transaccione.Empleados = empleadoHelper.GetAll();



            return View(transaccione);
        }

        // POST: TransaccioneController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransaccioneViewModel transaccione)
        {
            try
            {
                Token = HttpContext.Session.GetString("token");
                transaccioneHelper.Token = Token;

                transaccioneHelper.AddTransaccione(transaccione);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TransaccioneController/Edit/5
        public ActionResult Edit(int id)
        {
            Token = HttpContext.Session.GetString("token");
            transaccioneHelper.Token = Token;

            TransaccioneViewModel transaccione = transaccioneHelper.GetById(id);

            return View(transaccione);
        }

        // POST: TransaccioneController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TransaccioneViewModel transaccione)
        {
            try
            {
                Token = HttpContext.Session.GetString("token");
                transaccioneHelper.Token = Token;

                transaccioneHelper.EditTransaccione(transaccione);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TransaccioneController/Delete/5
        public ActionResult Delete(int id)
        {
            Token = HttpContext.Session.GetString("token");
            transaccioneHelper.Token = Token;

            TransaccioneViewModel transaccione = transaccioneHelper.GetById(id);

            return View(transaccione);
        }

        // POST: TransaccioneController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TransaccioneViewModel transaccione)
        {
            try
            {
                Token = HttpContext.Session.GetString("token");
                transaccioneHelper.Token = Token;

                transaccioneHelper.DeleteTransaccione(transaccione.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}