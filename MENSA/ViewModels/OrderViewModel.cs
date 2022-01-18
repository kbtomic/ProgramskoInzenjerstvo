using MENSA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MENSA.ViewModels
{
    public class OrderViewModel
    {
        public NewNarudzba Order { get; set; }
        
        public List<MenuViewModel> menuVM { get; set; }
    }
}
