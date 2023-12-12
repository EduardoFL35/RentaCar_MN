using FrontEnd.Helpers.Implementations;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    [Authorize]
    public class SeguroController : Controller
    {

        ISeguroHelper seguroHelper;
        public string Token { get; set; }


        public SeguroController(ISeguroHelper _seguroHelper)
        {
            seguroHelper = _seguroHelper;

        }
        // GET: SeguroController
        public ActionResult Index()
        {
            Token = HttpContext.Session.GetString("token");
            seguroHelper.Token = Token;
            List<SeguroViewModel> seguros = seguroHelper.GetAll();

            return View(seguros);
        }

        // GET: SeguroController/Details/5
        public ActionResult Details(int id)
        {

            Token = HttpContext.Session.GetString("token");
            seguroHelper.Token = Token;
            SeguroViewModel seguro = seguroHelper.GetById(id);

            return View(seguro);
        }

        // GET: SeguroController/Create
        public ActionResult Create()
        {

            Token = HttpContext.Session.GetString("token");
            seguroHelper.Token = Token;
            SeguroViewModel seguro = new SeguroViewModel();



            return View(seguro);
        }

        // POST: SeguroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SeguroViewModel seguro)
        {
            try
            {
                Token = HttpContext.Session.GetString("token");
                seguroHelper.Token = Token;

                seguroHelper.AddSeguro(seguro);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SeguroController/Edit/5
        public ActionResult Edit(int id)
        {
            Token = HttpContext.Session.GetString("token");
            seguroHelper.Token = Token;

            SeguroViewModel seguro = seguroHelper.GetById(id);

            return View(seguro);
        }

        // POST: SeguroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SeguroViewModel seguro)
        {
            try
            {
                Token = HttpContext.Session.GetString("token");
                seguroHelper.Token = Token;

                seguroHelper.EditSeguro(seguro);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SeguroController/Delete/5
        public ActionResult Delete(int id)
        {
            Token = HttpContext.Session.GetString("token");
            seguroHelper.Token = Token;

            SeguroViewModel seguro = seguroHelper.GetById(id);

            return View(seguro);
        }

        // POST: SeguroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(SeguroViewModel seguro)
        {
            try
            {
                Token = HttpContext.Session.GetString("token");
                seguroHelper.Token = Token;

                seguroHelper.DeleteSeguro(seguro.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}