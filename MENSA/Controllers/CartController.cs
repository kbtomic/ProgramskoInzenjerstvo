using MENSA.Data;
using MENSA.Helpers;
using MENSA.Models;
using MENSA.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MENSA.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CartController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<MenuViewModel>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;

            if (cart != null)
            {
                ViewBag.total = cart.Sum(item => item.Menu.Price * item.Quantity);

            }
            else {
                ViewBag.total = 0;
            }
            
            return View();
        }

        public IActionResult Buy(int id)
        {
            //Menu meal  = _db.Menu.Where(a => a.Id == id).FirstOrDefault();
            //MenuViewModel mealVM = new MenuViewModel();
            //mealVM.Menu = meal;


            
            if (SessionHelper.GetObjectFromJson<List<MenuViewModel>>(HttpContext.Session, "cart") == null)
            {
                Menu meal = _db.Menu.Where(a => a.Id == id).FirstOrDefault();
                MenuViewModel mealVM = new MenuViewModel();
                mealVM.Menu = meal;

                List<MenuViewModel> cart = new List<MenuViewModel>();
                mealVM.Quantity = 1;
                cart.Add(mealVM);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<MenuViewModel> cart = SessionHelper.GetObjectFromJson<List<MenuViewModel>>(HttpContext.Session, "cart");
                int index = isExist(id.ToString());
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    Menu meal = _db.Menu.Where(a => a.Id == id).FirstOrDefault();
                    MenuViewModel mealVM = new MenuViewModel();
                    mealVM.Menu = meal;

                    mealVM.Quantity = 1;
                    cart.Add(mealVM);
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            
            var menzaId = HttpContext.Session.GetInt32("currentMenzaId");
            return RedirectToAction("Select_Menu", "SelectMenza", new {ID = menzaId });
            
        }

        
        public IActionResult Remove(string id)
        {
            List<MenuViewModel> cart = SessionHelper.GetObjectFromJson<List<MenuViewModel>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        private int isExist(string id)
        {
            List<MenuViewModel> cart = SessionHelper.GetObjectFromJson<List<MenuViewModel>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Menu.Id.ToString().Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
