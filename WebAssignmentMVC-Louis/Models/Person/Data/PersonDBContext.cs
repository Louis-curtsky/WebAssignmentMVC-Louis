using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssignmentMVC.Models;

namespace WebAssignmentMVC.Models.Person.Data
{
    public class PersonDBContext: DbContext
    {
        public PersonDBContext(DbContextOptions<PersonDBContext>options):base(options)
        { }

        public DbSet<Person> Persons {get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
