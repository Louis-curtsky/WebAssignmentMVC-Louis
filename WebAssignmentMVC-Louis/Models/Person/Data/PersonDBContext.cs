using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssignmentMVC.Models;

namespace WebAssignmentMVC.Models.Person.Data
{
    public class PersonDBContext : DbContext
    {
        public PersonDBContext(DbContextOptions<PersonDBContext> options) : base(options)
        { }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region CountryCity Join Class Config

            modelBuilder.Entity<Country>()
                .HasKey(dt => dt.Id );

            modelBuilder.Entity<City>()
                .HasKey(dt => dt.Id);

            modelBuilder.Entity<City>()
                .HasOne(dtk => dtk.Countries)
                .WithMany(dt => dt.Cities)
                .HasForeignKey(dtk => dtk.CountryFiD);


            modelBuilder.Entity<City>().HasData(
                new City() { Id = 1, Name = "Stockholm", CountryFiD=1},
                new City() { Id = 2, Name = "Helsingborg", CountryFiD = 1 },
                new City() { Id = 3, Name = "Växjö", CountryFiD = 1 },
                new City() { Id = 4, Name = "Gävle", CountryFiD = 1 },
                new City() { Id = 5, Name = "Trollhättan", CountryFiD = 1 },
                new City() { Id = 6, Name = "Berlin", CountryFiD = 3 },
                new City() { Id = 7, Name = "Hamburg", CountryFiD = 3 },
                new City() { Id = 8, Name = "Munich", CountryFiD = 3 }
                );
/*
            modelBuilder.Entity<Country>().HasData(
                new Country() { Id = 1, Cname = "Sweden"  },
                new Country() { Id = 3, Cname = "Germany" }
                );
*/            
            #endregion

            #region Person Languag Join

            #endregion of Person Language Join
        }


    }
}
