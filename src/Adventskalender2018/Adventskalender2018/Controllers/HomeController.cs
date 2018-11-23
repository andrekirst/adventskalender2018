using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Adventskalender2018.Interfaces.Domain;
using Microsoft.AspNetCore.Mvc;
using Adventskalender2018.Models;

namespace Adventskalender2018.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAlleTuerenSpeicher _alleTuerenSpeicher;

        public HomeController(IAlleTuerenSpeicher alleTuerenSpeicher)
        {
            _alleTuerenSpeicher = alleTuerenSpeicher;
        }

        public async Task<IActionResult> Index()
        {
            AlleTuerenModel alleTuerenModel = new AlleTuerenModel
            {
                Adventstueren = await _alleTuerenSpeicher.GebeMirAlleAdventstueren()
            };

            return View(
                viewName: "Index",
                model: alleTuerenModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(model: new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
        }
    }
}
