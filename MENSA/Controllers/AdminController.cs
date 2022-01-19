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
     
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext _db;


        public AdminController(SignInManager<ApplicationUser> signInManager,
                                    UserManager<ApplicationUser> userManager, ApplicationDbContext db)

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
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);

                

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, model.userRole);
                    return View("Admin_functionalities");
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
            var menu = new Menu { Name = model.MealName, PicturePath = model.PicturePath, Price = model.Price };
            _db.Menu.Add(menu);
            _db.SaveChanges();
            

            var menuString = model.MealName;
            var menuParameter = new SqlParameter("@Name", menuString);
            var menuToAdd = _db.Menu.FromSqlRaw("SELECT * FROM Menu WHERE Name=@Name", menuParameter).FirstOrDefault(); //ID menua

            var menzaString = model.MenzaName;
            var menzaParameter = new SqlParameter("@Name", menzaString);
            var menzaToAdd = _db.Menza.FromSqlRaw("SELECT * FROM Menza WHERE Name=@Name", menzaParameter).FirstOrDefault(); //ID menze

            var obj = new Menza_Menu { Menu = menuToAdd, Menza = menzaToAdd, MenuId=menuToAdd.Id, MenzaId=menzaToAdd.Id, Availability = true };
            var commandText = "Insert Into [Menza_Menu](MenzaId, MenuId, Availability)values(@menzaId, @menuId, @availability)";
            var menzaIdparamater = new SqlParameter("@menzaId", obj.MenzaId);
            var menuIdparamater = new SqlParameter("@menuId", obj.MenuId);
            var availabilityParamater = new SqlParameter("@availability", obj.Availability);

            _db.Database.ExecuteSqlRaw(commandText, menzaIdparamater, menuIdparamater, availabilityParamater);
            //_db.Menza_Menu.Add(obj);
            //_db.SaveChanges();

            return View();
        }

        public IActionResult Admin_functionalities()
        {

            return View();
        }
    }
}
