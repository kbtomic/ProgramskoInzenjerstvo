using MENSA.Data;
using MENSA.Models;
using MENSA.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MENSA.Controllers
{
    public class AdminController : Controller
    {
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly ApplicationDbContext _db;


        public AdminController(SignInManager<IdentityUser> signInManager,
                                    UserManager<IdentityUser> userManager, ApplicationDbContext db)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            _db = db;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);

                

                if (result.Succeeded)
                {
                    return View();
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }


        public IActionResult Admin_menu()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Admin_menu(AddMenuViewModel model)
        {
            var menu = new Menu { Name = model.MealName, PicturePath = model.PicturePath, Price = model.Price, Availability = true };
            _db.Menu.Add(menu);
            _db.SaveChanges();

            var menuString = model.MealName;
            var menuParameter = new SqlParameter("@Name", menuString);
            var menuID = _db.Menu.FromSqlRaw("SELECT Id FROM Menu WHERE Name=@Name", menuParameter).FirstOrDefault(); //ID menua

            var menzaString = model.MenzaName;
            var menzaParameter = new SqlParameter("@Name", menzaString);
            var menzaID = _db.Menza.FromSqlRaw("SELECT Id FROM Menza WHERE Name=@Name", menzaParameter).FirstOrDefault(); //ID menze

            var obj = new Menza_Menu { MenuId = Convert.ToInt32(menuID), MenzaId = Convert.ToInt32(menzaID) };
            _db.Menza_Menu.Add(obj);
            _db.SaveChanges();

            return View();
        }

        public IActionResult Admin_functionalities()
        {

            return View();
        }
    }
}
