using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    [Authorize]
    public class EmpleadoController : Controller
    {

        IEmpleadoHelper empleadoHelper;
        public string Token { get; set; }


        public EmpleadoController(IEmpleadoHelper _empleadoHelper)
        {
            empleadoHelper = _empleadoHelper;

        }
        // GET: EmpleadoController
        public ActionResult Index()
        {
            Token = HttpContext.Session.GetString("token");
            empleadoHelper.Token = Token;
            List<EmpleadoViewModel> empleados = empleadoHelper.GetAll();

            return View(empleados);
        }

        // GET: EmpleadoController/Details/5
        public ActionResult Details(int id)
        {

            Token = HttpContext.Session.GetString("token");
            empleadoHelper.Token = Token;
            EmpleadoViewModel empleado = empleadoHelper.GetById(id);

            return View(empleado);
        }

        // GET: EmpleadoController/Create
        public ActionResult Create()
        {

            Token = HttpContext.Session.GetString("token");
            empleadoHelper.Token = Token;
            EmpleadoViewModel empleado = new EmpleadoViewModel();



            return View(empleado);
        }

        // POST: EmpleadoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmpleadoViewModel empleado)
        {
            try
            {
                Token = HttpContext.Session.GetString("token");
                empleadoHelper.Token = Token;

                empleadoHelper.AddEmpleado(empleado);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpleadoController/Edit/5
        public ActionResult Edit(int id)
        {
            Token = HttpContext.Session.GetString("token");
            empleadoHelper.Token = Token;

            EmpleadoViewModel empleado = empleadoHelper.GetById(id);

            return View(empleado);
        }

        // POST: EmpleadoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmpleadoViewModel empleado)
        {
            try
            {
                Token = HttpContext.Session.GetString("token");
                empleadoHelper.Token = Token;

                empleadoHelper.EditEmpleado(empleado);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpleadoController/Delete/5
        public ActionResult Delete(int id)
        {
            Token = HttpContext.Session.GetString("token");
            empleadoHelper.Token = Token;

            EmpleadoViewModel empleado = empleadoHelper.GetById(id);

            return View(empleado);
        }

        // POST: EmpleadoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(EmpleadoViewModel empleado)
        {
            try
            {
                Token = HttpContext.Session.GetString("token");
                empleadoHelper.Token = Token;

                empleadoHelper.DeleteEmpleado(empleado.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
