using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssignmentMVC.Controllers;
using WebAssignmentMVC.Models.Person.ViewModels;

namespace WebAssignmentMVC.Models.Person.Services
{
    public interface ICityService
    {
        City Create(CreateCityViewModel createCity);
        bool Edit(City city);
        string FindById(int id);
        public City GetCity(int id);
        List<City> GetAll();

        bool Remove(City city);
    }
}
