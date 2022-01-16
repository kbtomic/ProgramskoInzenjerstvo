using MENSA.Data;
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

        private readonly ApplicationDbContext _db;

        public SelectMenzaController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Menza> objList = _db.Menza;

            return View(objList);
        }

        

        public IActionResult Select_menu(int ID)
        {

            return View();
        }

        public IActionResult pregled_kosarice(int ID)
        {

            return View();
        }


    }
}
