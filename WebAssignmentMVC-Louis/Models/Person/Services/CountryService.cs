using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssignmentMVC.Models.Person;
using WebAssignmentMVC.Models.Person.Repo;
using WebAssignmentMVC.Models.Person.ViewModels;

namespace WebAssignmentMVC.Models.Person.Services
{
    public class CountryService: ICountryService
    {
        private readonly ICountryRepo _countryRepo;

        public CountryService(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;
        }
        public Country Create(CreateCountryViewModel country)
        {
            if (string.IsNullOrWhiteSpace(country.CountryName))
            {
                return null;
            }
            Country newCountry = new Country()
            {
                Cname = country.CountryName
            };
            return _countryRepo.Create(newCountry);
        }

        public List<Country> GetAll()
        {
            return _countryRepo.GetAll();
        }

        public List<Country> Search(string search)
        {
            List<Country> searchCountry = _countryRepo.GetAll();
            //
            foreach (Country item in _countryRepo.GetAll())
            {
                if (item.Cname.Contains(search, StringComparison.OrdinalIgnoreCase))
                {
                    searchCountry.Add(item);
                }
            }
            //searchPerson = searchPerson.Where(p => p.Name.ToUpper().Contains(search.ToUpper()) || p.City.Contains(search.ToUpper())).ToList();
            if (searchCountry.Count == 0)
            {
                throw new ArgumentException("Could not find what you where looking for");
            }
            return searchCountry;
        }

        public Country FindById(int id)
        {
            Country countryFound = _countryRepo.FindById(id);
            return countryFound;
        }
        public string Edit(int id, CreateCountryViewModel editCountry)
        {
            Country orginalCountry = FindById(id);
            if (orginalCountry == null)
            {
                return "Null Value detected!!!";
            }
            orginalCountry.Cname = editCountry.CountryName;
            return _countryRepo.Update(orginalCountry);
        }

        public bool Remove(int id)
        {
            Country country = _countryRepo.FindById(id);
            if (country != null)
                return _countryRepo.Delete(country);
            else
                return false;
        }
    }
}
