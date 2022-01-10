using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; //koristiti za foreign key
using System.Linq;
using System.Threading.Tasks;

namespace MENSA.Models
{
    public class Narudzba
    {
        [Key]
        public int Number { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [ForeignKey("Menza")]
        public int MenzaId { get; set; }
        public Menza Menza { get; set; }

    }
}
