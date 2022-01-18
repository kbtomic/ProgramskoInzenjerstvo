using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MENSA.Models
{
    public class NewNarudzba
    {
        [Key]
        public int Id { get; set; }

       
        public bool Ready { get; set; }
        public bool Delivered { get; set; }

        [ForeignKey("MenzaId")]
        public int MenzaId { get; set; }
        public Menza Menza { get; set; }

        public string StudentId { get; set; }
        [ForeignKey("StudentId")]
        public ApplicationUser ApplicationUser { get; set; }


        public ICollection<NewModel> NewModel { get; set; }
    }
}
