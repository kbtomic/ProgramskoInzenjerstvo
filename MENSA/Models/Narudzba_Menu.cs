using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MENSA.Models
{
    [Keyless]
    public class Narudzba_Menu
    {
        public int Quantity { get; set; }

        [ForeignKey("Menu")]
        public int MenuId { get; set; }
        public Menu Menu { get; set; }

        [ForeignKey("Narudzba")]
        public int NarudzbaNumber { get; set; }
        public Narudzba Narudzba { get; set; }
    }
}
