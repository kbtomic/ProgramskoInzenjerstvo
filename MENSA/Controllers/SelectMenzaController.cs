using MENSA.Models;
using MENSA.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MENSA.Controllers
{
    public class SelectMenzaController : Controller
    {
       

        public IActionResult Index()
        {
           
            return View();
        }

        public IActionResult Admin_menu()
        {

            return View();
        }

        public IActionResult Select_menu()
        {

            return View();
        }



    }
}
