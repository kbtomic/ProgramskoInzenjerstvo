using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MENSA.Models
{
    public class Student
    {
        [Key] //Key oznacava da je to ispod kljuc i da koristi identity svojstvo, treba ubacit using System.ComponentModel.DataAnnotations; da se moze koristit
        public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
