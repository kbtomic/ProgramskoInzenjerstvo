using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MENSA.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Narudzba> Narudzba { get; set; }
        public virtual ICollection<NewNarudzba> NewNarudzba { get; set; }
    }
}
