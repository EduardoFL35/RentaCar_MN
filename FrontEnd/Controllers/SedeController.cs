using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    [Authorize]
    public class SedeController : Controller
    {

        ISedeHelper sedeHelper;
        public string Token { get; set; }


        public SedeController(ISedeHelper _sedeHelper)
        {
            sedeHelper = _sedeHelper;

        }
        // GET: SedeController
        public ActionResult Index()
        {
            Token = HttpContext.Session.GetString("token");
            sedeHelper.Token = Token;
            List<SedeViewModel> sedes = sedeHelper.GetAll();

            return View(sedes);
        }

        // GET: SedeController/Details/5
        public ActionResult Details(int id)
        {

            Token = HttpContext.Session.GetString("token");
            sedeHelper.Token = Token;
            SedeViewModel sede = sedeHelper.GetById(id);

            return View(sede);
        }

        // GET: SedeController/Create
        public ActionResult Create()
        {

            Token = HttpContext.Session.GetString("token");
            sedeHelper.Token = Token;
            SedeViewModel sede = new SedeViewModel();



            return View(sede);
        }

        // POST: SedeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SedeViewModel sede)
        {
            try
            {
                Token = HttpContext.Session.GetString("token");
                sedeHelper.Token = Token;

                sedeHelper.AddSede(sede);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SedeController/Edit/5
        public ActionResult Edit(int id)
        {
            Token = HttpContext.Session.GetString("token");
            sedeHelper.Token = Token;

            SedeViewModel sede = sedeHelper.GetById(id);

            return View(sede);
        }

        // POST: SedeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SedeViewModel sede)
        {
            try
            {
                Token = HttpContext.Session.GetString("token");
                sedeHelper.Token = Token;

                sedeHelper.EditSede(sede);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SedeController/Delete/5
        public ActionResult Delete(int id)
        {
            Token = HttpContext.Session.GetString("token");
            sedeHelper.Token = Token;

            SedeViewModel sede = sedeHelper.GetById(id);

            return View(sede);
        }

        // POST: SedeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(SedeViewModel sede)
        {
            try
            {
                Token = HttpContext.Session.GetString("token");
                sedeHelper.Token = Token;

                sedeHelper.DeleteSede(sede.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
