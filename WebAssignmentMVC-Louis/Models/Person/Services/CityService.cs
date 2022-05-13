using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssignmentMVC.Controllers;
using WebAssignmentMVC.Models.Person.Repo;

namespace WebAssignmentMVC.Models.Person.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepo _cityRepo;

        public CityService(ICityRepo cityRepo)
        {
            _cityRepo = cityRepo;
        }
        public City Create(City createCity)
        {
            return _cityRepo.Create(createCity);
        }

        public bool Edit(City city)
        {
            if (_cityRepo.Update(city))
                return true;
            else
                return false;
        }

        public City FindById(int id)
        {
            return _cityRepo.FindById(id);
        }

        public List<City> GetAll()
        {
            return _cityRepo.GetAll();
        }

        public bool Remove(City city)
        {
            if (_cityRepo.Delete(city))
                return true;
            else
                return false;
        }

    }
}
