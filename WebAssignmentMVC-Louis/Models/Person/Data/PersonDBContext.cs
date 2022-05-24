using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssignmentMVC.Models;
using WebAssignmentMVC.Models.Identity;
using WebAssignmentMVC.Models.Person;
using WebAssignmentMVC.Models.Person.ViewModels;

namespace WebAssignmentMVC.Models.Person.Data
{
    public class PersonDBContext : IdentityDbContext<PersonUser>
    {
        public PersonDBContext(DbContextOptions<PersonDBContext> options) : base(options)
        { }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<PersonLanguage> PersonLanguage { get; set; }

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

            modelBuilder.Entity<Country>().HasData(
                new Country() { Id = 1, Cname = "Sweden"},
                new Country() { Id= 2, Cname= "France"},
                new Country() { Id = 3, Cname = "Germany"}
                );

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
           
            
            #endregion

            #region Person Languag Join
 
            modelBuilder.Entity<PersonLanguage>().HasKey(pl =>
            new {
               pl.PersonId,
               pl.LanguageId
            });

            modelBuilder.Entity<PersonLanguage>()
                .HasOne(pl => pl.Person)
                    .WithMany(p => p.languageSpoken)
                .HasForeignKey(pl => pl.PersonId);

            modelBuilder.Entity<PersonLanguage>()
                .HasOne(pl => pl.Language)
                    .WithMany(p => p.personLanguage)
                .HasForeignKey(pl=> pl.LanguageId);

            modelBuilder.Entity<Language>().HasData(
                new Language { Id = 1, LangName = "Swedish" },
                new Language { Id = 2, LangName = "English" },
                new Language { Id = 3, LangName = "Chinese" }
                );

            modelBuilder.Entity<Person>().HasData(
                new Person() { Id=1, FirstName = "Louis", LastName = "Lim", CtyId=1, CountryId=1, Phone = "0765551111" },
                new Person() { Id=2, FirstName = "Michael", LastName = "Kent", CtyId=2, CountryId=1, Phone = "0733338888"},
                new Person() { Id=3,FirstName = "Åsa", LastName = "Jason", CtyId=3, CountryId=1, Phone = "0721231234" },
                new Person() { Id=4, FirstName = "Andy", LastName = "Birch", CtyId=0, CountryId=2, Phone = "0744448888" },
                new Person() { Id=5, FirstName = "Johnny", LastName = "Walker", CtyId=0, CountryId=2, Phone = "0751244674" }
                );

            #endregion of Person Language Join

            #region Identity User Seeding
            string AdminId = Guid.NewGuid().ToString();
            modelBuilder.Entity<PersonUser>().HasData(new PersonUser
            {
                Id = AdminId,
                UserName = "Admin",
                Email = "admin@gmail.com",
                PasswordHash = new PasswordHasher<PersonUser>().HashPassword(null, "P@ssW0rd"),
                FirstName = "Louis",
                LastName = "Lim",
                EmailConfirmed = true,
                DateOfBirth = DateTime.Now
            });

            #endregion
        }


    }
}
