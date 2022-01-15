using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace MENSA.Models
{
    [Keyless]
    public class Zaposlenik_Menza
    {
        [ForeignKey("Menza")]
        public int MenzaId { get; set; }
        public Menza Menza { get; set; }

        public string ZaposlenikId { get; set; }
        [ForeignKey("ZaposlenikId")]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
