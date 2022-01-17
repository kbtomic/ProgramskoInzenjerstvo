using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MENSA.ViewModels
{
    public class AddMenuViewModel
    {
        public string MenzaName { get; set; }
        public string MealName { get; set; }
        public float Price { get; set; }
        public string PicturePath { get; set; }
    }
}
