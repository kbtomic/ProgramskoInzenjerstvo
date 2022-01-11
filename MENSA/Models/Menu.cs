using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MENSA.Models
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Price { get; set; }
        public bool Availability { get; set; }
        public string PicturePath { get; set; }

    }
}
