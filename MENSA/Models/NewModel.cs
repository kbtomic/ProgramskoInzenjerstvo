using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MENSA.Models
{
    public class NewModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Menu")]
        public int MenuId { get; set; }
        public Menu Menu { get; set; }

        [ForeignKey("NewNarudzba")]
        public int NewNarudzbaId { get; set; }
        public NewNarudzba NewNarudzba { get; set; }
    }
}
