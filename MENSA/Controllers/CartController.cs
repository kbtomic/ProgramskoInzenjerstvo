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
using Microsoft.AspNetCore.Identity;

namespace MENSA.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> userManager;

        public CartController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
            _db = db;
        }

        [Route("Index")]
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

        public async Task<IActionResult> ConfirmOrder()
        {
            List<MenuViewModel> cart = SessionHelper.GetObjectFromJson<List<MenuViewModel>>(HttpContext.Session, "cart");

            if (cart != null)
            {
                var currentMenzaId = HttpContext.Session.GetInt32("currentMenzaId");
                var currentMenza = _db.Menza.Find(currentMenzaId);

                var currentUser = await userManager.GetUserAsync(User);
                NewNarudzba newNarudzba = new NewNarudzba {MenzaId = (int)currentMenzaId ,Menza = currentMenza,Ready = false, Delivered = false, ApplicationUser = currentUser,StudentId = currentUser.Id };

                _db.NewNarudzba.Add(newNarudzba);
                _db.SaveChanges();

                int narudzbaId = newNarudzba.Id;

                foreach (var item in cart)
                {
                    for (int i = 0; i < item.Quantity; i++)
                    {

                        NewModel newModel = new NewModel {  NewNarudzbaId = narudzbaId, MenuId = item.Menu.Id };

                        _db.NewModel.Add(newModel);
                        _db.SaveChanges();
                    }

                }
                float priceTotal = cart.Sum(item => item.Menu.Price * item.Quantity);
                OrderNumberViewModel orderNumberVM = new OrderNumberViewModel { Narudzba = newNarudzba, Price = priceTotal };
                cart.Clear();
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

                return View("OrderNumber", orderNumberVM);
            }

            return View("Index");
        }

        
        public IActionResult OrderNumber(OrderNumberViewModel currentNarudzba)
        {
            
            
            return View(currentNarudzba);
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
