using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    [Authorize]
    public class MantenimientoController : Controller
    {

        IMantenimientoHelper mantenimientoHelper;
        public string Token { get; set; }


        public MantenimientoController(IMantenimientoHelper _mantenimientoHelper)
        {
            mantenimientoHelper = _mantenimientoHelper;

        }
        // GET: MantenimientoController
        public ActionResult Index()
        {
            Token = HttpContext.Session.GetString("token");
            mantenimientoHelper.Token = Token;
            List<MantenimientoViewModel> mantenimientos = mantenimientoHelper.GetAll();

            return View(mantenimientos);
        }

        // GET: MantenimientoController/Details/5
        public ActionResult Details(int id)
        {

            Token = HttpContext.Session.GetString("token");
            mantenimientoHelper.Token = Token;
            MantenimientoViewModel mantenimiento = mantenimientoHelper.GetById(id);

            return View(mantenimiento);
        }

        // GET: MantenimientoController/Create
        public ActionResult Create()
        {

            Token = HttpContext.Session.GetString("token");
            mantenimientoHelper.Token = Token;
            MantenimientoViewModel mantenimiento = new MantenimientoViewModel();



            return View(mantenimiento);
        }

        // POST: MantenimientoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MantenimientoViewModel mantenimiento)
        {
            try
            {
                Token = HttpContext.Session.GetString("token");
                mantenimientoHelper.Token = Token;

                mantenimientoHelper.AddMantenimiento(mantenimiento);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MantenimientoController/Edit/5
        public ActionResult Edit(int id)
        {
            Token = HttpContext.Session.GetString("token");
            mantenimientoHelper.Token = Token;

            MantenimientoViewModel mantenimiento = mantenimientoHelper.GetById(id);

            return View(mantenimiento);
        }

        // POST: MantenimientoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MantenimientoViewModel mantenimiento)
        {
            try
            {
                Token = HttpContext.Session.GetString("token");
                mantenimientoHelper.Token = Token;

                mantenimientoHelper.EditMantenimiento(mantenimiento);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MantenimientoController/Delete/5
        public ActionResult Delete(int id)
        {
            Token = HttpContext.Session.GetString("token");
            mantenimientoHelper.Token = Token;

            MantenimientoViewModel mantenimiento = mantenimientoHelper.GetById(id);

            return View(mantenimiento);
        }

        // POST: MantenimientoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(MantenimientoViewModel mantenimiento)
        {
            try
            {
                Token = HttpContext.Session.GetString("token");
                mantenimientoHelper.Token = Token;

                mantenimientoHelper.DeleteMantenimiento(mantenimiento.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}