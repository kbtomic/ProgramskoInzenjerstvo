using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MENSA.Models
{
    public class Menza
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime WorkingHours { get; set; }
        public string PicturePath { get; set; }

        public ICollection<Narudzba> Narudzba { get; set; }
    }
}
