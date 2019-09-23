using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Business; 
using DemoProject.Views;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Controllers
{
    public class VozController : Controller
    {
        IVozImageService _vozImageService;
        public VozController(IVozImageService vozImageService)
        {
            _vozImageService = vozImageService;
        }
        // GET: Voz
        public async Task<ActionResult> Index()
        {
            var ims = await _vozImageService.LoadAllPages($"https://forums.voz.vn/showthread.php?t=7631621");

            var images = new ImgsModel();
            images.Imgs = ims;
            return View("Imgs", ims.Distinct());
        }

        // GET: Voz/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var ims = await _vozImageService.LoadAllPages($"https://forums.voz.vn/showthread.php?t={id}");

            var images = new ImgsModel();
            images.Imgs = ims;
            return View("Imgs", ims.Distinct());
        }

        // GET: Voz/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Voz/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Voz/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Voz/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Voz/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Voz/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}