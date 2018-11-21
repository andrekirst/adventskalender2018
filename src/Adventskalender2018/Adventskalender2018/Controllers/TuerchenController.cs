using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Adventskalender2018.Models;
using Microsoft.AspNetCore.Mvc;

namespace Adventskalender2018.Controllers
{
    public class TuerchenController : Controller
    {
        public IActionResult Tuer(int tag)
        {
            return View(new TuerModel
            {
                Tag = tag
            });
        }
    }
}