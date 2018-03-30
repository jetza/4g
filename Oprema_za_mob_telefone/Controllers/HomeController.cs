﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Oprema_za_mob_telefone.Models;

namespace Oprema_za_mob_telefone.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = " ";

            return View();
        }

        public IActionResult Novosti()
        {
            ViewData["Message"] = " ";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = " ";

            return View();
        }
        public IActionResult Korpa()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
