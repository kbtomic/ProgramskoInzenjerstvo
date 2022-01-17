using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MENSA.Controllers
{
    public class OrderNumberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
