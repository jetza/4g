using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Oprema_za_mob_telefone.Views.Home
{
    public class KorpaController : Controller
    {
        // GET: Korpa
        public ActionResult Index()
        {
            return View();
        }

        // GET: Korpa/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Korpa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Korpa/Create
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

        // GET: Korpa/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Korpa/Edit/5
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

        // GET: Korpa/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Korpa/Delete/5
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