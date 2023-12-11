using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    [Authorize]
    public class CategoriaController : Controller
    {

        ICategoriaHelper categoriaHelper;
        public string Token { get; set; }


        public CategoriaController(ICategoriaHelper _categoriaHelper)
        {
            categoriaHelper = _categoriaHelper;
 
        }
        // GET: CategoriaController
        public ActionResult Index()
        {
            Token = HttpContext.Session.GetString("token");
            categoriaHelper.Token = Token;
            List<CategoriaViewModel> categorias = categoriaHelper.GetAll();

            return View(categorias);
        }

        // GET: CategoriaController/Details/5
        public ActionResult Details(int id)
        {

            Token = HttpContext.Session.GetString("token");
            categoriaHelper.Token = Token;
            CategoriaViewModel categoria = categoriaHelper.GetById(id);

            return View(categoria);
        }

        // GET: CategoriaController/Create
        public ActionResult Create()
        {

            Token = HttpContext.Session.GetString("token");
            categoriaHelper.Token = Token;
            CategoriaViewModel categoria = new CategoriaViewModel();



            return View(categoria);
        }

        // POST: CategoriaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoriaViewModel categoria)
        {
            try
            {
                Token = HttpContext.Session.GetString("token");
                categoriaHelper.Token = Token;

                categoriaHelper.AddCategoria(categoria);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriaController/Edit/5
        public ActionResult Edit(int id)
        {
            Token = HttpContext.Session.GetString("token");
            categoriaHelper.Token = Token;

            CategoriaViewModel categoria = categoriaHelper.GetById(id);

            return View(categoria);
        }

        // POST: CategoriaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoriaViewModel categoria)
        {
            try
            {
                Token = HttpContext.Session.GetString("token");
                categoriaHelper.Token = Token;

                categoriaHelper.EditCategoria(categoria);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoriaController/Delete/5
        public ActionResult Delete(int id)
        {
            Token = HttpContext.Session.GetString("token");
            categoriaHelper.Token = Token;

            CategoriaViewModel categoria = categoriaHelper.GetById(id);

            return View(categoria);
        }

        // POST: CategoriaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(CategoriaViewModel categoria)
        {
            try
            {
                Token = HttpContext.Session.GetString("token");
                categoriaHelper.Token = Token;

                categoriaHelper.DeleteCategoria(categoria.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}