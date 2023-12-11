using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    [Authorize]
    public class AutomovileController : Controller
    {

        IAutomovileHelper automovileHelper;
        ICategoriaHelper categoriaHelper;
        ISedeHelper sedeHelper;
        ISeguroHelper seguroHelper;

        public string Token { get; set; }


        public AutomovileController(IAutomovileHelper _automovileHelper
                                    , ICategoriaHelper _categoriaHelper
                                    , ISedeHelper _sedeHelper
                                    , ISeguroHelper _seguroHelper
                                    )
        {
            automovileHelper = _automovileHelper;
            categoriaHelper = _categoriaHelper;
            sedeHelper = _sedeHelper;
            seguroHelper = _seguroHelper;
        }
        // GET: AutomovileController
        public ActionResult Index()
        {
            Token = HttpContext.Session.GetString("token");
            automovileHelper.Token = Token;
            List<AutomovileViewModel> automoviles = automovileHelper.GetAll();

            return View(automoviles);
        }

        // GET: AutomovileController/Details/5
        public ActionResult Details(int id)
        {

            Token = HttpContext.Session.GetString("token");
            automovileHelper.Token = Token;
            AutomovileViewModel automovile = automovileHelper.GetById(id);

            return View(automovile);
        }

        // GET: AutomovileController/Create
        public ActionResult Create()
        {

            Token = HttpContext.Session.GetString("token");
            automovileHelper.Token = Token;

            AutomovileViewModel automovile = new AutomovileViewModel();
            automovile.Categorias = categoriaHelper.GetAll();
            automovile.Sedes = sedeHelper.GetAll();
            automovile.Seguros = seguroHelper.GetAll();



            return View(automovile);
        }

        // POST: AutomovileController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AutomovileViewModel automovile)
        {
            try
            {
                Token = HttpContext.Session.GetString("token");
                automovileHelper.Token = Token;

                automovileHelper.AddAutomovile(automovile);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AutomovileController/Edit/5
        public ActionResult Edit(int id)
        {
            Token = HttpContext.Session.GetString("token");
            automovileHelper.Token = Token;

            AutomovileViewModel automovile = automovileHelper.GetById(id);

            return View(automovile);
        }

        // POST: AutomovileController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AutomovileViewModel automovile)
        {
            try
            {
                Token = HttpContext.Session.GetString("token");
                automovileHelper.Token = Token;

                automovileHelper.EditAutomovile(automovile);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AutomovileController/Delete/5
        public ActionResult Delete(int id)
        {
            Token = HttpContext.Session.GetString("token");
            automovileHelper.Token = Token;

            AutomovileViewModel automovile = automovileHelper.GetById(id);

            return View(automovile);
        }

        // POST: AutomovileController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(AutomovileViewModel automovile)
        {
            try
            {
                Token = HttpContext.Session.GetString("token");
                automovileHelper.Token = Token;

                automovileHelper.DeleteAutomovile(automovile.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}