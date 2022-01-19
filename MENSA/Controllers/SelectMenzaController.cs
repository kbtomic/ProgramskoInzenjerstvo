using MENSA.Data;
using MENSA.Helpers;
using MENSA.Models;
using MENSA.ViewModels;
using Microsoft.AspNetCore.Http;
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
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext _db;

        public SelectMenzaController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
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
            HttpContext.Session.SetInt32("currentMenzaId", ID);
            var currentMenza = _db.Menza.Where(a => a.Id == ID).FirstOrDefault();
            HttpContext.Session.SetString("currentMenzaName", currentMenza.Name);

            var menzaMeals = (from mm in _db.Menza_Menu
                              join me in _db.Menu on mm.MenuId equals me.Id
                              where mm.MenzaId == ID && mm.Availability == true
                              select new Menu
                              {
                                  Id = me.Id,
                                  Name = me.Name,
                                  PicturePath = me.PicturePath,
                                  Price = me.Price
                              }).ToList();

            
            return View(menzaMeals);
        }

        

        public async Task<IActionResult> Orders(int ID)
        {
            var currentOrders = _db.NewNarudzba.Where(o => o.MenzaId == ID); //dohvaca narudzbe za menzu

            List<OrderViewModel> ordersVM = new List<OrderViewModel>(); //ovo cemo poslati viewu
            
            int i = 0;

            foreach (var item in currentOrders)
            {
                var orderUser = await userManager.FindByIdAsync(item.StudentId);
                item.ApplicationUser = orderUser; //dohvaca korisnika narudzbe ------------------------------>ne radi, triba popravit nekako

                ordersVM.Add(new OrderViewModel {Order = item });
                ordersVM[i].menuVM = new List<MenuViewModel>();

                var newModels = _db.NewModel.Where(m => m.NewNarudzbaId == item.Id); //dohvaca sva jela za tu narudzbu

                foreach (var obj in newModels)
                {
                    var meal = _db.Menu.Where(m => m.Id == obj.MenuId).FirstOrDefault();
                    MenuViewModel tempMenuVm = new MenuViewModel { Menu = meal, Quantity = 1 };

                    bool containsItem = ordersVM[i].menuVM.Any(x => x.Menu.Id == meal.Id);

                    if (containsItem == true)
                    {
                        int index = ordersVM[i].menuVM.FindIndex(x => x.Menu.Id == meal.Id);
                        ordersVM[i].menuVM[index].Quantity++;
                    }
                    else {
                        ordersVM[i].menuVM.Add(tempMenuVm);

                    }

                    
                }
                i++;
            }
            

            return View(ordersVM);
        }

    }
}
