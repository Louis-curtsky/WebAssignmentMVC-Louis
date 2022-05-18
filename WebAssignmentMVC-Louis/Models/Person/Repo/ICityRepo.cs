using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssignmentMVC.Controllers;
using WebAssignmentMVC.Models.Person.ViewModels;

namespace WebAssignmentMVC.Models.Person.Repo
{
    public interface ICityRepo
    {
        City Create(City city);
        List<City> GetAll();
        string FindById(int id);
        public City GetCity(int id);

        bool Update(City city);
        bool Delete(City city);
    }
}
