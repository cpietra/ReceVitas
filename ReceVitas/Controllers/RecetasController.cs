using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ReceVitas.Controllers
{
    public class RecetasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}