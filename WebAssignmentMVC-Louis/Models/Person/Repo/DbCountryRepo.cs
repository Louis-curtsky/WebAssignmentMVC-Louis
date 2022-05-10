using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssignmentMVC.Models.Person.Data;

namespace WebAssignmentMVC.Models.Person.Repo
{
    public class DbCountryRepo : ICountryRepo
    {
        readonly PersonDBContext _personDBContext;

        public DbCountryRepo(PersonDBContext personDBContext)
        {
            _personDBContext = personDBContext;
        }
        public Country Create(Country country)
        {
            _personDBContext.Countries.Add(country);
            _personDBContext.SaveChanges();
            return country;
        }

        public bool Delete(Country country)
        {
            _personDBContext.Countries.Remove(country);
            int returnValue = _personDBContext.SaveChanges();
            return returnValue == 1 ? true : false;
        }

        public Country FindById(int id)
        {
            return _personDBContext.Countries.Find(id);
        }

        public List<Country> GetAll()
        {
            List<Country> countryList = _personDBContext.Countries.ToList();
            return countryList;
        }

     
        public string Update(Country country)
        {
            _personDBContext.Countries.Update(country);
            int returnValue = _personDBContext.SaveChanges();
            return returnValue == 1 ? "User profile has been updated successfully" : "Unable to update";
        }
    } // End of Public Class
} // End of NameSpace 
