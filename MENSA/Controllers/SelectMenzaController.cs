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

        
        [HttpGet]
        public IActionResult Select_menu(int ID)
        {
          

            var menzaMeals = (from mm in _db.Menza_Menu
                              join me in _db.Menu on mm.MenuId equals me.Id
                              where mm.MenzaId == ID
                              select new Menu
                              {
                                  Id = me.Id,
                                  Name = me.Name,
                                  PicturePath = me.PicturePath,
                                  Price = me.Price
                              }).ToList();


            return View(menzaMeals);
        }

        public IActionResult pregled_kosarice()
        {

            return View();
        }

        public IActionResult Orders(int ID)
        {
            return View();
        }

    }
}
