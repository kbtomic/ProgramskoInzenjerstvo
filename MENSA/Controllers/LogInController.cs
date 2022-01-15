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
    public class LogInController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;


        //private readonly ILogger<LogInController> _logger;

        //public LogInController(ILogger<LogInController> logger)
        //{
        //    _logger = logger;
        //}

        public LogInController(SignInManager<ApplicationUser> signInManager, 
                                    UserManager<ApplicationUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        
        public IActionResult Index()
        {
            if (signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "SelectMenza");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "SelectMenza");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            
            return View("Index", model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }


        /*private readonly ApplicationDbContext _db;

       public LogInController(ApplicationDbContext db)
       {
           _db = db;
       }*/
        /*//Post - login
        [HttpPost]
        [ValidateAntiForgeryToken] //za sigurnost(da podaci nisu promijenjeni od submitanja podataka do dolaska ovde)
        public IActionResult LogIn(Student obj)
        {
            var emailParamater = new SqlParameter("@Email", obj.Email);
            var passwordParametar = new SqlParameter("@Password", obj.Password);
            var tempStudent = _db.Student.FromSqlRaw("SELECT * FROM Student WHERE Email=@Email AND Password=@Password", emailParamater, passwordParametar).FirstOrDefault();

            //tempStudent - student koji se logira

            if (tempStudent != null)
            {
             
                return RedirectToAction("Index", "SelectMenza");
            }
            else
            {
                return View("Index");
            }
            
        }Za oni jednostavni unos  */


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
