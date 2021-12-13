using MENSA.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MENSA.Data
{
    //DbContext nam sluzi za komunikaciju sa bazon i kako bi mogli slat podatke u bazu
    // da bi koristili DbContext to moramo naslijediti od EntityFrameworkCore (using Microsoft.EntityFrameworkCore;)
    // tj posto koristimo Identyty onda IdentityDbContext (u njemu se nalazi i DbContext)
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) //konstruktor
        {

        }

        public DbSet<Student> Student { get; set; } //nadodajemo ovo kako bi mogli nas model ubaciti u bazu
                                                    // da mos koristit model Student moras koristit using MENSA.Models;
    }
}
