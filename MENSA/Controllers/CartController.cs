using MENSA.Data;
using MENSA.Helpers;
using MENSA.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            var cart = SessionHelper.GetObjectFromJson<List<Menu>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            //ViewBag.total = cart.Sum(item => item.Product.Price * item.Quantity);
            return View();
        }

        public IActionResult Buy(int id)
        {
            Menu meal  = _db.Menu.Where(a => a.Id == id).FirstOrDefault();

            if (SessionHelper.GetObjectFromJson<List<Menu>>(HttpContext.Session, "cart") == null)
            {
                List<Menu> cart = new List<Menu>();
                cart.Add(meal);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Menu> cart = SessionHelper.GetObjectFromJson<List<Menu>>(HttpContext.Session, "cart");
                int index = isExist(id.ToString());
                if (index != -1)
                {
                    //cart[index].Quantity++;
                }
                else
                {
                    cart.Add(meal);
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Select_Menu", "SelectMenza");
        }

        
        public IActionResult Remove(string id)
        {
            List<Menu> cart = SessionHelper.GetObjectFromJson<List<Menu>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        private int isExist(string id)
        {
            List<Menu> cart = SessionHelper.GetObjectFromJson<List<Menu>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Id.ToString().Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
