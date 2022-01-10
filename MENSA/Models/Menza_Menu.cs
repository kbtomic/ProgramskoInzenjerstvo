using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MENSA.Models
{
    [Keyless]
    public class Menza_Menu
    {
        [ForeignKey("Menu")]
        public int MenuId { get; set; }
        public Menu Menu { get; set; }

        [ForeignKey("Menza")]
        public int MenzaId { get; set; }
        public Menza Menza { get; set; }
    }
}
