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


        public Country FindById(int id)
        {
            return _countryRepo.FindById(id);
        }
        public Country Edit(int id, CreateCountryViewModel editCountry)
        {
            Country editedCountry = new Country() { Id = id, Cname = editCountry.CountryName };
            return _countryRepo.Update(editedCountry);
        }

        public bool Remove(int id)
        {
            if (_countryRepo.FindById(id) != null)
            {
                Country country = _countryRepo.GetCountry(id);
                return _countryRepo.Delete(country);
            }
            else
                return false;
        }
    }
}
